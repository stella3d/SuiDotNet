
using System;
using System.Text.RegularExpressions;

namespace SuiDotNet.Client
{
    internal static class StringTypes
    {
        static readonly Regex AddressPattern = new Regex("^(0x)?[a-fA-F0-9]{40}$");
        // allow short forms of address for objects, like 0x2, 0x03 for standard library
        static readonly Regex ObjectIdPattern = new Regex("^(0x)?[a-fA-F0-9]{1,40}$");
        static readonly Regex TxDigestPattern = new Regex("^(?:[a-zA-Z0-9+\\/]{43})=$");

        public static bool IsValidSuiAddress(string str)
        {
            return AddressPattern.IsMatch(str);
        }
        
        public static bool IsValidSuiObjectId(string str)
        {
            return ObjectIdPattern.IsMatch(str);
        }
        
        public static bool IsValidSuiTransactionDigest(string str)
        {
            return TxDigestPattern.IsMatch(str);
        }
        
        const string TxDigestErrMsg = "must be a 44-character base64 string";
        internal static void ThrowIfNotTxDigest(string str, string argName = "txDigest")
        {
            if (!IsValidSuiTransactionDigest(str))
                throw new ArgumentException(TxDigestErrMsg, argName);
        }

    }
}

