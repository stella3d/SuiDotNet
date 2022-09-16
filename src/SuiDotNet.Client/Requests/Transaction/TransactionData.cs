using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class TransactionData
    {
        [JsonProperty("gasBudget", Required = Required.Always)]
        public ulong GasBudget { get; set; }
        [JsonProperty("gasPayment", Required = Required.Always)]
        public SuiObjectReference GasPayment { get; set; }

        [JsonProperty("sender", Required = Required.Always)]
        public string Sender { get; set; }
        
        [JsonProperty("transactions", Required = Required.Always)]
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
            var objId = $"\n\tobjId: '{GasPayment.ObjectId}'";
            var digest = $"\n\ttxDigest: '{GasPayment.Digest}'";
            var txes = string.Join(",\n", Transactions);
            return "{\n" +
                   $"  gasBudget: {GasBudget},\n" +
                   $"  gasPayment: {{{digest},{objId}\n}},\n" +
                   $"  transactions: [\n{txes}\n]" +
                   "}";
        }
    }
}