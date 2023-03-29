using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ChatCMD
{
    internal class ApiKeyManager
    {
        private const string ApiKeyFileName = "apikey.txt";
        private const string EntropyFileName = "entropy.bin";
        private static readonly byte[] Entropy = GetEntropy();

        public static string GetApiKey()
        {
            if (File.Exists(ApiKeyFileName))
            {
                string encryptedApiKey = File.ReadAllText(ApiKeyFileName);
                return Unprotect(encryptedApiKey);
            }

            return null;
        }

        public static void SaveApiKey(string apiKey)
        {
            string encryptedApiKey = Protect(apiKey);
            File.WriteAllText(ApiKeyFileName, encryptedApiKey);
        }

        private static byte[] GetEntropy()
        {
            if (File.Exists(EntropyFileName))
            {
                return File.ReadAllBytes(EntropyFileName);
            }

            using var rng = new RNGCryptoServiceProvider();
            byte[] entropy = new byte[16];
            rng.GetBytes(entropy);

            File.WriteAllBytes(EntropyFileName, entropy);
            return entropy;
        }

        private static string Protect(string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] protectedBytes = ProtectedData.Protect(dataBytes, Entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedBytes);
        }

        private static string Unprotect(string protectedData)
        {
            byte[] protectedBytes = Convert.FromBase64String(protectedData);
            byte[] dataBytes = ProtectedData.Unprotect(protectedBytes, Entropy, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(dataBytes);
        }
    }
}