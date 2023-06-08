// Copyright 2023 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License").
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at 
//
// https://www.apache.org/licenses/LICENSE-2.0 
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and 
// limitations under the License.

using Google.Api.Gax;
using Google.Cloud.Bigtable.Admin.V2;
using Google.Cloud.Bigtable.Common.V2;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;

namespace Google.Cloud.Bigtable.V2.BenchmarkingTool;

public class BigTableInitializer
{
    public static readonly string ProjectId = "docssamples";
    public static readonly string InstanceId = "bigtabletest";

    public readonly TableName TableName = new TableName(ProjectId, InstanceId, "testtable");
    public readonly InstanceName InstanceName = new InstanceName(ProjectId, InstanceId);

    public const string DefaultColumnFamily = "cf1";
    public const string DefaultColumnQualifier = "row_exists";
    public const string DefaultValue = "true";
    public const string OtherColumnFamily = "test_data";
    protected Table CreateDefaultTable() => new Table
    {
        Granularity = Table.Types.TimestampGranularity.Millis,
        ColumnFamilies =
        {
            { DefaultColumnFamily, new ColumnFamily { GcRule = new GcRule { MaxNumVersions = 3 } } },
            { OtherColumnFamily, new ColumnFamily { GcRule = new GcRule { MaxNumVersions = 3 } } }
        }
    };

    public async Task InitialTasksAsync()
    {
        var TableAdminClient = new BigtableTableAdminClientBuilder { EmulatorDetection = EmulatorDetection.EmulatorOrProduction }.Build();
        var tableClient = new BigtableClientBuilder { EmulatorDetection = EmulatorDetection.EmulatorOrProduction }.Build();

        // Creating a table name `testtable`.
        await TableAdminClient.CreateTableAsync(InstanceName, TableName.TableId, CreateDefaultTable());

        // Inserting a row into bigtable with RowKey = row1.
        var rowKey = await InsertRowAsync(TableName, version: new BigtableVersion(1));

        async Task<BigtableByteString> InsertRowAsync(TableName tableName, string? familyName = null, BigtableByteString? qualifierName = null,
        BigtableByteString? value = null, BigtableVersion? version = null)
        {
            BigtableByteString rowKey = "row1";

            familyName = familyName ?? DefaultColumnFamily;
            qualifierName = qualifierName ?? DefaultColumnQualifier;
            value = value ?? DefaultValue;

            await tableClient.MutateRowAsync(tableName, rowKey, Mutations.SetCell(familyName, qualifierName.Value, value.Value, version));

            return rowKey;
        }
    }

}

public class Program
{
    private const long TimeSpanTicksPerMicrosecond = 10;
    private ConcurrentQueue<string> logsThread1 = new ConcurrentQueue<string>();
    private ConcurrentQueue<string> logsThread2 = new ConcurrentQueue<string>();
    private ConcurrentQueue<string> logsThread3 = new ConcurrentQueue<string>();

    private async Task ExportLogs(string path, ConcurrentQueue<string> logs)
    {
        using StreamWriter writer = new StreamWriter(path, true);
        while (logs.TryDequeue(out var res))
        {
            await writer.WriteLineAsync(res);
        }
    }

    public async Task Work1(TableName tableName)
    {
        BigtableByteString rowKey = "invalid-rowId";
        long requestid = 0;

        while (true)
        {
            var stopwatch = Stopwatch.StartNew();

            var client = BigtableClient.Create();
            var row = client.ReadRow(tableName, rowKey);

            var lapsedTimeUs = (stopwatch.Elapsed.Ticks/ TimeSpanTicksPerMicrosecond).ToString(CultureInfo.InvariantCulture);
            logsThread1.Enqueue($"Thread1: latency in request : {requestid} is: {lapsedTimeUs}");
            requestid++;
            // Wait for 10 sec before making next request.
            await Task.Delay(1000 * 10);
        }
    }

    public async Task Work2(TableName tableName)
    {
        BigtableByteString rowKey = "invalid-rowId";
        var client = BigtableClient.Create();
        long requestid = 0;
        while (true)
        {
            var stopwatch = Stopwatch.StartNew();

            var row = client.ReadRow(tableName, rowKey);

            var lapsedTimeUs = (stopwatch.Elapsed.Ticks / TimeSpanTicksPerMicrosecond).ToString(CultureInfo.InvariantCulture);
            logsThread2.Enqueue($"Thread2: latency in request : {requestid} is: {lapsedTimeUs}");
            requestid++;
            // Wait for 10 sec before making next request.
            await Task.Delay(1000 * 10);
        }
    }

    public async Task Work3(TableName tableName, InstanceName instanceName)
    {
        BigtableByteString rowKey = "invalid-rowId";

        var client = BigtableClient.Create();
        client.PingAndWarm(instanceName);
        var channelStartTime = DateTime.UtcNow;
        long requestid = 0;

        while (true)
        {
            var timeTillNow = DateTime.UtcNow - channelStartTime;
            if (timeTillNow.TotalMinutes > 45)
            {
                channelStartTime = DateTime.UtcNow;
                SwapClient();
            }
            var stopwatch = Stopwatch.StartNew();

            var row = client.ReadRow(tableName, rowKey);

            var lapsedTimeUs = (stopwatch.Elapsed.Ticks / TimeSpanTicksPerMicrosecond).ToString(CultureInfo.InvariantCulture);
            logsThread3.Enqueue($"Thread3: latency in request : {requestid} is: {lapsedTimeUs}");
            requestid++;
            // Wait for 10 sec before making next request.
            await Task.Delay(1000 * 10);
        }
        async void SwapClient()
        {
            var newClient = BigtableClient.Create();
            await newClient.PingAndWarmAsync(instanceName);
            client = newClient;
        }
    }

    private async void ConsumeBackgroundTask(Task task, string purpose)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (Exception)
        {
            Console.WriteLine($"Error in background session pool task for {purpose}");
        }
    }

    private async Task ExportThreadLogs()
    {
        Console.WriteLine("Exporting logs");
        ConsumeBackgroundTask(ExportLogs(".//log1.txt", logsThread1), "Export logs 1");
        ConsumeBackgroundTask(ExportLogs(".//log2.txt", logsThread2), "Export logs 2");
        ConsumeBackgroundTask(ExportLogs(".//log3.txt", logsThread3), "Export logs 3");
        await Task.Delay(1000 * 60);
        ConsumeBackgroundTask(ExportThreadLogs(), "Exporting logs for both the threads");
    }

    public static async Task Main(string[] args)
    {
        var p = new Program();
        var bigTableInitializer = new BigTableInitializer();
        await bigTableInitializer.InitialTasksAsync();
        var thread1 = new Thread(async () => await p.Work1(bigTableInitializer.TableName));
        var thread2 = new Thread(async () => await p.Work2(bigTableInitializer.TableName));
        var thread3 = new Thread(async () => await p.Work3(bigTableInitializer.TableName, bigTableInitializer.InstanceName));

        // Start the threads.
        thread1.Start();
        thread2.Start();
        thread3.Start();

        p.ConsumeBackgroundTask(p.ExportThreadLogs(), "final exporting");

        // Wait for the threads to finish.
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Done!");
    }
}
