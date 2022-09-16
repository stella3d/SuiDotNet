using System;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiParsedTransactionResponse
    {
        public object? Publish { get; }
        public object? MergeCoin { get; }
        public object? SplitCoin { get; }

        public SuiParsedTransactionResponse(
            object? publish = null,
            object? mergeCoin = null,
            object? splitCoin = null)
        {
            Publish = publish;
            MergeCoin = mergeCoin;
            SplitCoin = splitCoin;
        }
    }
}