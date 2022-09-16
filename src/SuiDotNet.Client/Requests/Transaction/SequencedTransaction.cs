namespace SuiDotNet.Client.Requests
{
    // in JSON, a SequencedTransaction is serialized as a 2-member mixed type array:
    // [sequenceNumber: number, digest: string]
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