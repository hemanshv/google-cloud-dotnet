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

using Google.Cloud.Bigtable.Common.V2;
using Google.Cloud.Bigtable.V2;
using Grpc.Auth;
using Grpc.Core;
using Grpc.Net.Client;
using System.Diagnostics;
using System.Globalization;

public class Program
{
    private const long TimeSpanTicksPerMicrosecond = 10;
    public static async Task Main(string[] args)
    {
        //BigtableServiceApiClient.ServiceMetadata
        string endpoint = "dns:///bigtable.googleapis.com:443";
        string ProjectId = "docssamples";
        string InstanceId = "bigtabletest";
        BigtableByteString rowKey = "invalid-rowId";

        var channelCredentials = await GoogleGrpcCredentials.GetApplicationDefaultAsync();
        var channel = GrpcChannel.ForAddress(endpoint, new GrpcChannelOptions { Credentials = channelCredentials});

        // Create a CallInvoker instance.
        var invoker = channel.CreateCallInvoker();
        Bigtable.BigtableClient grpcClient = new Bigtable.BigtableClient(invoker);

        TableName TableName = new TableName(ProjectId, InstanceId, "testtable");
        ReadRowsRequest readRowsRequest = new ReadRowsRequest
        {
            TableNameAsTableName = TableName,
            Rows = new RowSet { RowKeys = { rowKey.Value } }
        };
        int requestid = 0;
        while (true)
        {
            var stopwatch = Stopwatch.StartNew();

            var response = grpcClient.ReadRows(readRowsRequest);
            while (await response.ResponseStream.MoveNext())
            {
                Console.WriteLine("inside loop");
                Console.WriteLine(response.ResponseStream.Current);
            }

            var lapsedTimeUs = (stopwatch.Elapsed.Ticks / TimeSpanTicksPerMicrosecond).ToString(CultureInfo.InvariantCulture);
            Console.WriteLine($"latency in request : {requestid} is: {lapsedTimeUs}");
            requestid++;
            await Task.Delay(1000 * 10);
        }

    }
}
