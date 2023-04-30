using System.Security.Cryptography;

namespace DotNetCryptography.Encryptors;

public static class AesEncryptor
{
    public static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
    {
        ArgumentException.ThrowIfNullOrEmpty(plainText);
        ArgumentNullException.ThrowIfNull(key);
        ArgumentNullException.ThrowIfNull(iv);

        byte[] cipherText;
        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    cipherText = msEncrypt.ToArray();
                }
            }
        }

        return cipherText;
    }

    public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        string plaintext;

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (var msDecrypt = new MemoryStream(cipherText))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {

                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }

    public static byte[] GenerateRandomIv(int bytes = 16)
    {
        var randomBytes = new byte[bytes];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);

        return randomBytes;
    }
}
