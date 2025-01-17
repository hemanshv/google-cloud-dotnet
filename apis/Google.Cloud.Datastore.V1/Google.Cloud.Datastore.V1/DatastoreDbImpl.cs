// Copyright 2016 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Gax;
using Google.Api.Gax.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Google.Cloud.Datastore.V1.CommitRequest.Types;
using static Google.Cloud.Datastore.V1.ReadOptions.Types;

namespace Google.Cloud.Datastore.V1
{
    /// <summary>
    /// Wrapper around <see cref="DatastoreClient"/> to provide simpler operations.
    /// </summary>
    /// <remarks>
    /// This is the "default" implementation of <see cref="DatastoreDb"/>. Most client code
    /// should refer to <see cref="DatastoreDb"/>, creating instances with
    /// <see cref="DatastoreDb.Create(string, string, DatastoreClient)"/>. The constructor
    /// of this class is public for the sake of constructor-based dependency injection.
    /// </remarks>
    public sealed class DatastoreDbImpl : DatastoreDb
    {
        /// <inheritdoc/>
        public override DatastoreClient Client { get; }

        /// <inheritdoc/>
        public override string ProjectId { get; }

        /// <inheritdoc/>
        public override string NamespaceId { get; }

        private readonly PartitionId _partitionId;

        /// <summary>
        /// Constructs an instance from the given project ID, namespace ID and client.
        /// </summary>
        /// <remarks>This constructor is primarily provided for constructor-based dependency injection.
        /// The static <see cref="DatastoreDb.Create(string, string, DatastoreClient)"/> method is provided
        /// for manually obtaining an instance, including automatic client creation.</remarks>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="namespaceId">The namespace ID. Must not be null.</param>
        /// <param name="client">The client to use for underlying operations. Must not be null.</param>
        public DatastoreDbImpl(string projectId, string namespaceId, DatastoreClient client) : base()
        {
            ProjectId = GaxPreconditions.CheckNotNull(projectId, nameof(projectId));
            NamespaceId = GaxPreconditions.CheckNotNull(namespaceId, nameof(namespaceId));
            _partitionId = new PartitionId(projectId, namespaceId);
            Client = GaxPreconditions.CheckNotNull(client, nameof(client));
        }

        /// <inheritdoc/>
        public override KeyFactory CreateKeyFactory(string kind) => new KeyFactory(_partitionId, kind);
        
        /// <inheritdoc/>
        public override LazyDatastoreQuery RunQueryLazily(
            Query query,
            ReadConsistency? readConsistency = null,
            CallSettings callSettings = null)
        {
            GaxPreconditions.CheckNotNull(query, nameof(query));
            var request = new RunQueryRequest
            {
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                Query = query,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var streamer = new QueryStreamer(request, Client.RunQueryApiCall, callSettings);
            return new LazyDatastoreQuery(streamer.Sync());
        }

        /// <inheritdoc/>
        public override AggregationQueryResults RunAggregationQuery(AggregationQuery query, ReadConsistency? readConsistency = null, CallSettings callSettings = null)
        {
            var request = new RunAggregationQueryRequest
            {
                AggregationQuery = query,
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var runAggregationQueryResponse = Client.RunAggregationQuery(request, callSettings);
            return AggregationQueryResults.FromRunAggregationQueryResponse(runAggregationQueryResponse);
        }

        /// <inheritdoc/>
        public override AggregationQueryResults RunAggregationQuery(GqlQuery query, ReadConsistency? readConsistency = null, CallSettings callSettings = null)
        {
            var request = new RunAggregationQueryRequest
            {
                GqlQuery = query,
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var runAggregationQueryResponse = Client.RunAggregationQuery(request, callSettings);
            return AggregationQueryResults.FromRunAggregationQueryResponse(runAggregationQueryResponse);
        }

        /// <inheritdoc/>
        public override async Task<AggregationQueryResults> RunAggregationQueryAsync(AggregationQuery query, ReadConsistency? readConsistency = null, CallSettings callSettings = null)
        {
            var request = new RunAggregationQueryRequest
            {
                AggregationQuery = query,
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var runAggregationQueryResponse = await Client.RunAggregationQueryAsync(request, callSettings).ConfigureAwait(false);
            return AggregationQueryResults.FromRunAggregationQueryResponse(runAggregationQueryResponse);
        }

        /// <inheritdoc/>
        public override async Task<AggregationQueryResults> RunAggregationQueryAsync(GqlQuery query, ReadConsistency? readConsistency = null, CallSettings callSettings = null)
        {
            var request = new RunAggregationQueryRequest
            {
                GqlQuery = query,
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var runAggregationQueryResponse = await Client.RunAggregationQueryAsync(request, callSettings).ConfigureAwait(false);
            return AggregationQueryResults.FromRunAggregationQueryResponse(runAggregationQueryResponse);
        }

        /// <inheritdoc/>
        public override AsyncLazyDatastoreQuery RunQueryLazilyAsync(
            Query query,
            ReadConsistency? readConsistency = null,
            CallSettings callSettings = null)
        {
            GaxPreconditions.CheckNotNull(query, nameof(query));
            var request = new RunQueryRequest
            {
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                Query = query,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var streamer = new QueryStreamer(request, Client.RunQueryApiCall, callSettings);
            return new AsyncLazyDatastoreQuery(streamer.Async());
        }

        /// <inheritdoc/>
        public override LazyDatastoreQuery RunQueryLazily(
            GqlQuery gqlQuery,
            ReadConsistency? readConsistency = null,
            CallSettings callSettings = null)
        {
            GaxPreconditions.CheckNotNull(gqlQuery, nameof(gqlQuery));
            var request = new RunQueryRequest
            {
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                GqlQuery = gqlQuery,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var streamer = new QueryStreamer(request, Client.RunQueryApiCall, callSettings);
            return new LazyDatastoreQuery(streamer.Sync());
        }

        /// <inheritdoc/>
        public override AsyncLazyDatastoreQuery RunQueryLazilyAsync(
            GqlQuery gqlQuery,
            ReadConsistency? readConsistency = null,
            CallSettings callSettings = null)
        {
            GaxPreconditions.CheckNotNull(gqlQuery, nameof(gqlQuery));
            var request = new RunQueryRequest
            {
                ProjectId = ProjectId,
                PartitionId = _partitionId,
                GqlQuery = gqlQuery,
                ReadOptions = GetReadOptions(readConsistency)
            };
            var streamer = new QueryStreamer(request, Client.RunQueryApiCall, callSettings);
            return new AsyncLazyDatastoreQuery(streamer.Async());
        }

        /// <inheritdoc/>
        public override DatastoreTransaction BeginTransaction(CallSettings callSettings = null) =>
            DatastoreTransaction.Create(Client, ProjectId, NamespaceId, Client.BeginTransaction(ProjectId, callSettings).Transaction);

        /// <inheritdoc/>
        public override async Task<DatastoreTransaction> BeginTransactionAsync(CallSettings callSettings = null)
        {
            var response = await Client.BeginTransactionAsync(ProjectId, callSettings).ConfigureAwait(false);
            return DatastoreTransaction.Create(Client, ProjectId, NamespaceId, response.Transaction);
        }

        /// <inheritdoc/>
        public override DatastoreTransaction BeginTransaction(TransactionOptions options, CallSettings callSettings = null)
        {
            var request = new BeginTransactionRequest { ProjectId = ProjectId, TransactionOptions = options };
            var response = Client.BeginTransaction(request, callSettings);
            return DatastoreTransaction.Create(Client, ProjectId, NamespaceId, response.Transaction);
        }

        /// <inheritdoc/>
        public override async Task<DatastoreTransaction> BeginTransactionAsync(TransactionOptions options, CallSettings callSettings = null)
        {
            var request = new BeginTransactionRequest { ProjectId = ProjectId, TransactionOptions = options };
            var response = await Client.BeginTransactionAsync(request, callSettings).ConfigureAwait(false);
            return DatastoreTransaction.Create(Client, ProjectId, NamespaceId, response.Transaction);
        }

        /// <inheritdoc/>
        public override IReadOnlyList<Key> AllocateIds(IEnumerable<Key> keys, CallSettings callSettings = null)
        {
            // TODO: Validation. All keys should be non-null, and have a filled in path element
            // until the final one, which should just have a kind. Or we could just let the server validate...
            keys = GaxPreconditions.CheckNotNull(keys, nameof(keys)).ToList();
            var response = Client.AllocateIds(ProjectId, keys, callSettings);
            return response.Keys.ToList();
        }

        /// <inheritdoc/>
        public override async Task<IReadOnlyList<Key>> AllocateIdsAsync(IEnumerable<Key> keys, CallSettings callSettings = null)
        {
            // TODO: Validation. All keys should be non-null, and have a filled in path element
            // until the final one, which should just have a kind. Or we could just let the server validate...
            keys = GaxPreconditions.CheckNotNull(keys, nameof(keys)).ToList();
            var response = await Client.AllocateIdsAsync(ProjectId, keys, callSettings).ConfigureAwait(false);
            return response.Keys.ToList();
        }

        /// <inheritdoc/>
        public override IReadOnlyList<Entity> Lookup(IEnumerable<Key> keys, ReadConsistency? readConsistency = null, CallSettings callSettings = null)
            => LookupImpl(Client, ProjectId, GetReadOptions(readConsistency), keys, callSettings);

        /// <inheritdoc/>
        public override Task<IReadOnlyList<Entity>> LookupAsync(IEnumerable<Key> keys, ReadConsistency? readConsistency = null, CallSettings callSettings = null)
            => LookupImplAsync(Client, ProjectId, GetReadOptions(readConsistency), keys, callSettings);

        // Non-transactional mutations

        /// <inheritdoc/>
        public override IReadOnlyList<Key> Insert(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            Commit(entities, e => e.ToInsert(), SetKey, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override Task<IReadOnlyList<Key>> InsertAsync(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            CommitAsync(entities, e => e.ToInsert(), SetKey, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override IReadOnlyList<Key> Upsert(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            Commit(entities, e => e.ToUpsert(), SetKey, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override Task<IReadOnlyList<Key>> UpsertAsync(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            CommitAsync(entities, e => e.ToUpsert(), SetKey, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override void Update(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            Commit(entities, e => e.ToUpdate(), null, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override Task UpdateAsync(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            CommitAsync(entities, e => e.ToUpdate(), null, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override void Delete(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            Commit(entities, e => e.ToDelete(), null, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override Task DeleteAsync(IEnumerable<Entity> entities, CallSettings callSettings = null) =>
            CommitAsync(entities, e => e.ToDelete(), null, nameof(entities), callSettings);

        /// <inheritdoc/>
        public override void Delete(IEnumerable<Key> keys, CallSettings callSettings = null) =>
            Commit(keys, e => e.ToDelete(), null, nameof(keys), callSettings);

        /// <inheritdoc/>
        public override Task DeleteAsync(IEnumerable<Key> keys, CallSettings callSettings = null) =>
            CommitAsync(keys, e => e.ToDelete(), null, nameof(keys), callSettings);

        private IReadOnlyList<Key> Commit<T>(IEnumerable<T> values, Func<T, Mutation> conversion, Action<T, Key> keyPropagation, string parameterName, CallSettings callSettings)
        {
            // TODO: Validation

            // Ensure we only iterate over values once
            var valuesList = values.ToList();
            var response = Client.Commit(ProjectId, Mode.NonTransactional, valuesList.Select(conversion), callSettings);
            PropagateKeys(valuesList, response, keyPropagation);

            return response.MutationResults.Select(mr => mr.Key).ToList();
        }

        private async Task<IReadOnlyList<Key>> CommitAsync<T>(IEnumerable<T> values, Func<T, Mutation> conversion, Action<T, Key> keyPropagation, string parameterName, CallSettings callSettings)
        {
            // TODO: Validation

            // Ensure we only iterate over values once
            var valuesList = values.ToList();
            var response = await Client.CommitAsync(ProjectId, Mode.NonTransactional, values.Select(conversion), callSettings).ConfigureAwait(false);
            PropagateKeys(valuesList, response, keyPropagation);

            return response.MutationResults.Select(mr => mr.Key).ToList();
        }

        private static void PropagateKeys<T>(IList<T> values, CommitResponse response, Action<T, Key> keyPropagation)
        {
            if (keyPropagation == null)
            {
                return;
            }
            for (int i = 0; i < values.Count; i++)
            {
                var key = response.MutationResults[i].Key;
                if (key != null)
                {
                    keyPropagation(values[i], key);
                }
            }
        }

        private static void SetKey(Entity entity, Key key) => entity.Key = key;

        private static ReadOptions GetReadOptions(ReadConsistency? readConsistency) =>
            readConsistency == null ? null : new ReadOptions { ReadConsistency = readConsistency.Value };
    }
}
