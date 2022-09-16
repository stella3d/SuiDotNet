namespace SuiDotNet.Client.Requests
{
    public class SequencedTransaction
    {
        public ulong SequenceNumber { get; set; }
        public string Digest { get; set; }

        public override string ToString()
        {
            return $"[{SequenceNumber}, \"{Digest}\"]";
        }
    }
}