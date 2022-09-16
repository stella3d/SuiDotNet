using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class TransactionData
    {
        [JsonProperty("gasBudget")]
        public ulong GasBudget { get; }
        [JsonProperty("gasPayment")]
        public SuiObjectReference GasPayment { get; }

        [JsonProperty("sender")]
        public string Sender { get; }
        
        [JsonProperty("transactions")]
        public object[] Transactions { get; }

        public TransactionData(ulong budget, SuiObjectReference payment, string sender, object[] transactions)
        {
            GasBudget = budget;
            GasPayment = payment;
            Sender = sender;
            Transactions = transactions;
        }

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