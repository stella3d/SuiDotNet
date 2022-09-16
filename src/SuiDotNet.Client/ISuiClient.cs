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
        Task<object[]> GetEventsByTransaction(string txDigest, uint count = SuiJsonClient.EventQueryMaxLimit);

        Task<object[]> GetEventsByModule(
            string package,
            string module,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<object[]> GetEventsByMoveEventStructName(
            string moveEventStructName,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<object[]> GetEventsBySender(
            string senderAddress,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<object[]> GetEventsByRecipient(
            ObjectOwner recipient,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<object[]> GetEventsByObject(
            string objectId,
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
        
        Task<object[]> GetEventsByTimeRange(
            uint count = SuiJsonClient.EventQueryMaxLimit,
            ulong startTime = 0,
            ulong endTime = ulong.MaxValue);
    }
}