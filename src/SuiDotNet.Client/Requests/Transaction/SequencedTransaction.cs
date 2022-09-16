using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuiDotNet.Client.Requests
{
    // in JSON, a SequencedTransaction is serialized as a 2-member mixed type array:
    // [sequenceNumber: number, digest: string]
    public class SequencedTransaction
    {
        public ulong SequenceNumber { get; set; }
        public string Digest { get; set; }
        
        public SequencedTransaction (object[] raw)
        {
            SequenceNumber = Convert.ToUInt64(raw[0]);
            Digest = (string) raw[1];
        }
        
        internal static SequencedTransaction[] CastRawSequencedTxes(object[][] rawTxes)
        {
            return rawTxes
                .Select(CastRawSequencedTx)
                .ToArray();
        }
        
        internal static SequencedTransaction CastRawSequencedTx(object[] rawTx)
        {
            return new SequencedTransaction(rawTx);
        }
        
        internal static SequencedTransaction[] CombineRawTxSequences(Task<object[][]>[] tasks)
        {
            var resultCount = 0;
            foreach (var t in tasks)
                resultCount += t.Result.Length;

            var results = new SequencedTransaction[resultCount];
            var resultIndex = 0;
            foreach (var t in tasks)
            {
                foreach (var tx in t.Result)
                {
                    results[resultIndex] = CastRawSequencedTx(tx);
                    resultIndex++;
                }
            }

            return results;
        }

        public override string ToString()
        {
            return $"[{SequenceNumber}, \"{Digest}\"]";
        }
    }
}