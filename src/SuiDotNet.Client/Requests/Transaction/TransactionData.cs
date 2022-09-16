using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class TransactionData
    {
        [JsonProperty("gasBudget")]
        public ulong GasBudget { get; set; }
        [JsonProperty("gasPayment")]
        public SuiObjectReference GasPayment { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }
        
        [JsonProperty("transactions")]
        public object[] Transactions { get; set; }

        public override string ToString()
        {
            var objId = $"\n\tobj id: {GasPayment.ObjectId}";
            var digest = $"\n\ttx digest: {GasPayment.Digest}";
            var paymentLines = $"\ngas payment: {{{digest},{objId}\n}}";
            var txes = string.Join(",\n", Transactions);
            return $"gas budget: {GasBudget},{paymentLines}\ntransactions: [\n\t{txes}\n]";
        }
    }
}