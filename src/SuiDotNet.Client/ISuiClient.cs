using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuiDotNet.Client.Requests;

namespace SuiDotNet.Client
{
    public interface ISuiClient
    {
        Task<SuiObjectInfo[]> GetObjectsOwnedByAddress(string address);

        Task<SuiObject?> GetObject(SuiObjectInfo objectInfo);
        Task<SuiObject?> GetObject(string objectId);
        Task<T?> GetObject<T>(string objectId) where T : class;
        Task<object?> GetObject(string objectId, Type objectType);

        Task<SuiObject[]> GetObjects(params SuiObjectInfo[] objectInfos);
        Task<SuiObject[]> GetObjects(params string[] objectIds);
        Task<T[]> GetObjects<T>(params SuiObjectInfo[] objectInfos) where T : class;
        Task<object[]> GetObjects(Type objectType, params SuiObjectInfo[] objectInfos);
        Task<T[]> GetObjects<T>(params string[] objectIds) where T : class;
        Task<object[]> GetObjects(Type objectType, params string[] objectIds);

        // sui_getTransaction* RPC methods
        Task<SuiTransactionResponse> GetTransactionWithEffects(string txDigest);
        Task<SuiTransactionResponse[]> GetTransactionWithEffectsBatch(ICollection<string> txDigests);
        Task<SequencedTransaction[]> GetTransactionsForAddress(string address);
        Task<SequencedTransaction[]> GetTransactionsForObject(string objectId);

        Task<ulong> GetTotalTransactionNumber();
        Task<SequencedTransaction[]> GetRecentTransactions(uint count = 20);
        Task<SequencedTransaction[]> GetTransactionDigestsInRange(ulong start, ulong end);
        
        // sui_getEvent* RPC methods
        Task<SuiEventEnvelope[]> GetEventsByTransaction(string txDigest, uint count = SuiJsonClient.EventQueryMaxLimit);

        Task<SuiEventEnvelope[]> GetEventsByModule(
            string package,
            string module,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<SuiEventEnvelope[]> GetEventsByMoveEventStructName(
            string moveEventStructName,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<SuiEventEnvelope[]> GetEventsBySender(
            string senderAddress,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<SuiEventEnvelope[]> GetEventsByRecipient(
            ObjectOwner recipient,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<SuiEventEnvelope[]> GetEventsByObject(
            string objectId,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<SuiEventEnvelope[]> GetEventsByTimeRange(
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = long.MaxValue);
    }
}