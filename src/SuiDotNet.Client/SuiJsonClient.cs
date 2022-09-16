using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using SuiDotNet.Client.Requests;

namespace SuiDotNet.Client
{
    public class SuiJsonClient : ISuiClient
    {
        private readonly SuiClientSettings _settings;
        private readonly RpcClient _rpcClient;

        public SuiJsonClient(SuiClientSettings settings) : this(new Uri(settings.BaseUri))
        {
            _settings = settings;
        }

        public SuiJsonClient(Uri rpcEndpoint)
        {
            _settings = new SuiClientSettings();
            var serializerOptions = DefaultJsonSerializerSettingsFactory.BuildDefaultJsonSerializerSettings();
            _rpcClient = new RpcClient(rpcEndpoint, jsonSerializerSettings: serializerOptions);
        }

        public async Task SyncAccountState(string address)
        {
            await _rpcClient.SendRequestAsync("sui_syncAccountState", null, address);
        }

        public async Task<SuiObjectInfo[]> GetObjectsOwnedByAddress(string address)
        {
            var objects = await _rpcClient.SendRequestAsync<SuiObjectInfo[]>("sui_getObjectsOwnedByAddress", null, address);
            return objects;
        }

        public Task<SuiObject?> GetObject(SuiObjectInfo objectInfo)
        {
            return GetObject(objectInfo.ObjectId);
        }

        public async Task<SuiObject?> GetObject(string objectId)
        {
            var obj = await _rpcClient.SendRequestAsync<ObjectDataResponse>("sui_getObject", null, objectId);
            if (obj.Status == SuiObjectStatus.Exists)
            {
                return obj.Details;
            }

            return null;
        }

        public async Task<T?> GetObject<T>(string objectId) where T : class
        {
            var obj = await GetObject(objectId, typeof(T));
            if (obj == null)
                return null;

            return (T)obj;
        }

        public async Task<object?> GetObject(string objectId, Type objectType)
        {
            var suiObject = await GetObject(objectId);
            if (suiObject == null)
                return null;

            if (!SuiEx.IsOfSuiType(objectType, suiObject.Data.Type, _settings.PackageIdOverrides))
                throw new Exception($"Found SuiObject with DataType {suiObject.Data.Type} does not match annotated type.");

            return SuiEx.ObjectFromDictionary(suiObject.Data.Fields, objectType);
        }

        public Task<SuiObject[]> GetObjects(params SuiObjectInfo[] objectInfos)
        {
            return GetObjects(objectInfos.Select(x => x.ObjectId).ToArray());
        }

        public async Task<SuiObject[]> GetObjects(params string[] objectIds)
        {
            if (!objectIds.Any())
                return Array.Empty<SuiObject>();
            
            var request = new SuiGetObject(_rpcClient);

            var batchRequest = new RpcRequestResponseBatch();
            for (int i = 0; i < objectIds.Length; i++)
            {
                batchRequest.BatchItems.Add(
                    new RpcRequestResponseBatchItem<SuiGetObject, ObjectDataResponse>(
                        request, request.BuildRequest(objectIds[i], i))
                );
            }

            var response = await _rpcClient.SendBatchRequestAsync(batchRequest);

            var responses = response.BatchItems.OfType<RpcRequestResponseBatchItem<SuiGetObject, ObjectDataResponse>>()
                .Select(x => x.Response).ToArray();

            return responses.Where(x => x.Status == SuiObjectStatus.Exists).Select(x => x.Details).ToArray()!;
        }

        public async Task<T[]> GetObjects<T>(params SuiObjectInfo[] objectInfos) where T : class
        {
            return (await GetObjects(typeof(T), objectInfos)).OfType<T>().ToArray();
        }

        public async Task<object[]> GetObjects(Type objectType, params SuiObjectInfo[] objectInfos)
        {
            objectInfos = objectInfos.Where(x => SuiEx.IsOfSuiType(objectType, x.Type, _settings.PackageIdOverrides)).ToArray();
            var objects = await GetObjects(objectInfos);
            var typedObjects = objects.Select(x => SuiEx.ObjectFromDictionary(x.Data.Fields, objectType)).ToArray();
            return typedObjects;
        }

        public async Task<T[]> GetObjects<T>(params string[] objectIds) where T : class
        {
            var objects = await GetObjects(typeof(T), objectIds);
            return objects.OfType<T>().ToArray();
        }

        public async Task<object[]> GetObjects(Type objectType, params string[] objectIds)
        {
            var objects = await GetObjects(objectIds);
            return objects
                .Where(x => SuiEx.IsOfSuiType(objectType, x.Data.Type, _settings.PackageIdOverrides))
                .Select(x => SuiEx.ObjectFromDictionary(x.Data.Fields, objectType))
                .ToArray();
        }

        public async Task<SuiTransactionResponse> GetTransactionWithEffects(string txDigest)
        {
            StringTypes.ThrowIfNotTxDigest(txDigest);
            return await _rpcClient.SendRequestAsync<SuiTransactionResponse>("sui_getTransaction", null, txDigest);
        }
        
        public async Task<SuiTransactionResponse[]> GetTransactionWithEffectsBatch(ICollection<string> txDigests)
        {
            if (!txDigests.Any())
                return Array.Empty<SuiTransactionResponse>();
            if (!txDigests.All(StringTypes.IsValidSuiTransactionDigest))
                throw new ArgumentException("must all be 44-character base64 strings", nameof(txDigests));

            var request = new SuiGetTransaction(_rpcClient);
            var batchRequest = new RpcRequestResponseBatch();
            var batchIndex = 0;
            foreach (var digest in txDigests)
            {
                batchRequest.BatchItems.Add(
                    new RpcRequestResponseBatchItem<SuiGetTransaction, SuiTransactionResponse>(
                        request, request.BuildRequest(digest, batchIndex))
                );
                batchIndex++;
            }

            var response = await _rpcClient.SendBatchRequestAsync(batchRequest);

            var responses = response.BatchItems
                .OfType<RpcRequestResponseBatchItem<SuiGetTransaction, SuiTransactionResponse>>()
                .Select(x => x.Response)
                .ToArray();

            return responses;
        }
        
        public async Task<SequencedTransaction[]> GetTransactionsForAddress(string address)
        {
            if (!StringTypes.IsValidSuiAddress(address))
                throw new ArgumentException("must be a 20-byte hex string", nameof(address));
            
            var tasks = new Task<object[][]>[2];
            // it's much easier to deserialize mixed-type JSON arrays as object[], then cast them after
            tasks[0] = _rpcClient.SendRequestAsync<object[][]>("sui_getTransactionsToAddress", null, address);
            tasks[1] = _rpcClient.SendRequestAsync<object[][]>("sui_getTransactionsFromAddress", null, address);
            await Task.WhenAll(tasks);
            
            return SequencedTransaction.CombineRawTxSequences(tasks);
        }

        public async Task<SequencedTransaction[]> GetTransactionsForObject(string objectId)
        {
            StringTypes.ThrowIfNotObjectId(objectId);
            
            var tasks = new Task<object[][]>[2];
            tasks[0] = _rpcClient.SendRequestAsync<object[][]>("sui_getTransactionsByInputObject", null, objectId);
            tasks[1] = _rpcClient.SendRequestAsync<object[][]>("sui_getTransactionsByMutatedObject", null, objectId);
            await Task.WhenAll(tasks);
            
            return SequencedTransaction.CombineRawTxSequences(tasks);
        }
        
        public async Task<ulong> GetTotalTransactionNumber()
        {
            return await _rpcClient.SendRequestAsync<ulong>("sui_getTotalTransactionNumber");
        }

        public async Task<SequencedTransaction[]> GetRecentTransactions(uint count = 20)
        {
            var raw = await _rpcClient.SendRequestAsync<object[][]>("sui_getRecentTransactions", null, count);
            return SequencedTransaction.CastRawSequencedTxes(raw);
        }

        public async Task<SequencedTransaction[]> GetTransactionDigestsInRange(ulong start, ulong end)
        {
            var raw = await _rpcClient.SendRequestAsync<object[][]>
                ("sui_getTransactionsInRange", null, start, end);
            return SequencedTransaction.CastRawSequencedTxes(raw);
        }


        internal const uint EventQueryMaxLimit = 100;
        static void LimitEventCount(ref uint input)
        {
            input = input < EventQueryMaxLimit ? input : EventQueryMaxLimit;
        }

        public async Task<object[]> GetEventsByTransaction(string txDigest, uint count = EventQueryMaxLimit)
        {
            StringTypes.ThrowIfNotTxDigest(txDigest);
            LimitEventCount(ref count);

            var asObjects = await _rpcClient.SendRequestAsync<object[]>
                ("sui_getEventsByTransaction", null, txDigest, count);

            return asObjects;
        }

        public async Task<SuiEventEnvelope[]> GetEventsByModule(
            string package,
            string module,
            uint count = EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue)
        {
            LimitEventCount(ref count);
            
            throw new NotImplementedException();
        }

        public async Task<SuiEventEnvelope[]> GetEventsByMoveEventStructName(
            string moveEventStructName,
            uint count = EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue)
        {
            LimitEventCount(ref count); 

            throw new NotImplementedException();
        }

        public async Task<SuiEventEnvelope[]> GetEventsBySender(
            string senderAddress,
            uint count = EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue)
        {
            StringTypes.ThrowIfNotSuiAddress(senderAddress);
            LimitEventCount(ref count); 

            throw new NotImplementedException();
        }

        public async Task<SuiEventEnvelope[]> GetEventsByRecipient(
            ObjectOwner recipient,
            uint count = EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue)
        {
            LimitEventCount(ref count); 

            throw new NotImplementedException();
        }

        public async Task<object[]> GetEventsByObject(
            string objectId,
            uint count = EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue)
        {
            StringTypes.ThrowIfNotObjectId(objectId);
            LimitEventCount(ref count); 
            
            var raw = await _rpcClient.SendRequestAsync<object[]>
                ("sui_getEventsByObject", null, objectId, count, startTime, endTime);

            return raw;
        }

        public async Task<object[]> GetEventsByTimeRange(
            uint count = EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = long.MaxValue)
        {
            LimitEventCount(ref count); 
            
            var raw = await _rpcClient.SendRequestAsync<object[]>
                ("sui_getEventsByTimeRange", null, count, startTime, endTime);

            return raw;/*
                .Select(r => new SuiEventEnvelope(r))
                .ToArray();
            */
        }
    }
}