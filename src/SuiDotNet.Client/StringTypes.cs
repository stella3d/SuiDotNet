
using System.Text.RegularExpressions;

namespace SuiDotNet.Client
{
    internal static class StringTypes
    {
        static readonly Regex AddressPattern = new Regex("^(0x)?[a-fA-F0-9]{40}$");
        static readonly Regex TxDigestPattern = new Regex(
            "^(?:[a-zA-Z0-9+\\/]{4})*(?:|(?:[a-zA-Z0-9+\\/]{3}=)|(?:[a-zA-Z0-9+\\/]{2}==)|(?:[a-zA-Z0-9+\\/]{1}===))$");
        
        public static bool IsValidSuiAddress(string str)
        {
            return AddressPattern.IsMatch(str);
        }
        
        public static bool IsValidSuiTransactionDigest(string str)
        {
            return TxDigestPattern.IsMatch(str);
        }
    }
}

