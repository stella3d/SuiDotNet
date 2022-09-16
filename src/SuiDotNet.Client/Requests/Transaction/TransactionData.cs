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
            var txes = string.Join(",\n", Transactions);
            return "{\n" +
                   $"  gasBudget: {GasBudget},\n" +
                   $"  gasPayment: {{{digest},{objId}\n}},\n" +
                   $"  transactions: [\n{txes}\n]" +
                   "}";
        }
    }
}