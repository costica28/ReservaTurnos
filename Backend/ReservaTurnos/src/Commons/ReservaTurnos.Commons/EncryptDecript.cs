using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ReservaTurnos.Commons
{
    public static  class EncryptDecript
    {
        public static string Encript(string plainText, string EncriptionKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncriptionKey);
            byte[] sha256Bytes;

            using(SHA256 sha256 = SHA256.Create())
            {
                sha256Bytes = sha256.ComputeHash(keyBytes);
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = sha256Bytes;
                aes.IV = new byte[16];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plaintBytes = Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plaintBytes, 0, plaintBytes.Length);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decript(string plainText, string EncriptionKey)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncriptionKey);
            byte[] sha256Bytes;

            using (SHA256 sha256 = SHA256.Create())
            {
                sha256Bytes = sha256.ComputeHash(keyBytes);
            }

            byte[] encryptedBytes = Convert.FromBase64String(plainText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = sha256Bytes;
                aes.IV = new byte[16];
                aes.Padding = PaddingMode.Zeros;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}
