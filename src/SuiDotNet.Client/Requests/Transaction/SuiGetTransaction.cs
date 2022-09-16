using System;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace SuiDotNet.Client.Requests
{
    public class SuiGetTransaction : RpcRequestResponseHandler<SuiTransactionResponse>
    {
        public SuiGetTransaction(IClient client) : base(client, "sui_getTransaction")
        {
        }

        public Task<SuiTransactionResponse> SendRequestAsync(string txDigest, object? id = null)
        {
            if (txDigest == null) throw new ArgumentNullException(nameof(txDigest));
            return SendRequestAsync(id, txDigest);
        }

        public RpcRequest BuildRequest(string txDigest, object? id = null)
        {
            if (txDigest == null) throw new ArgumentNullException(nameof(txDigest));
            return BuildRequest(id, txDigest);
        }
    }
}