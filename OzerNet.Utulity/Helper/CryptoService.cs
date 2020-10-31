using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace OzerNet.Utulity.Helper
{
    public static class CryptoService
    {
        private const string EncryptionKey = "66'3KR3M**-c75d4de3-f515-47a2-b5a2-dd8cd532910e-**0Z3R'66";
        private const string RgbKey8 = "_!3kR3m*";
        private const string RgbIv8 = "Ek3R_M!#";
        private const string RgbKey24 = "_!3kR3m*][-}{#0z3R@$#+66";

        public static string ToMd5(string input)
        {
            var md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            var inputArray = ConvertToByteArray(input);
            inputArray = md5CryptoServiceProvider.ComputeHash(inputArray);
            var stringBuilder = new StringBuilder();
            foreach (var arrayItem in inputArray)
            {
                stringBuilder.Append(arrayItem.ToString("x2").ToLower());
            }
            return stringBuilder.ToString();
        }

        public static string ToSha1(string input)
        {
            var sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
            var inputArray = ConvertToByteArray(input);
            var hashArray = sha1CryptoServiceProvider.ComputeHash(inputArray);
            return BitConverter.ToString(hashArray);
        }

        public static string ToSha256(string input)
        {
            var sha256Managed = new SHA256Managed();
            var inputArray = ConvertToByteArray(input);
            var hashArray = sha256Managed.ComputeHash(inputArray);
            return BitConverter.ToString(hashArray);
        }

        public static string ToSha384(string input)
        {
            var sha384Managed = new SHA384Managed();
            var inputArray = ConvertToByteArray(input);
            var hashArray = sha384Managed.ComputeHash(inputArray);
            return BitConverter.ToString(hashArray);
        }

        public static string ToSha512(string input)
        {
            var sha512Managed = new SHA512Managed();
            var inputArray = ConvertToByteArray(input);
            var hashArray = sha512Managed.ComputeHash(inputArray);
            return BitConverter.ToString(hashArray);
        }

        public static string ToDesEncryption(string input)
        {
            var rgbKey = ConvertToByte8Array(RgbKey8);
            var rgbIv = ConvertToByte8Array(RgbIv8);
            var desCryptoServiceProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
            var streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(input);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            var result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            streamWriter.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            return result;
        }

        public static string ToDesDecrypt(string input)
        {
            var rgbKey = ConvertToByte8Array(RgbKey8);
            var rgbIv = ConvertToByte8Array(RgbIv8);
            var desCryptoServiceProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream(Convert.FromBase64String(input));
            var cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Read);
            var streamReader = new StreamReader(cryptoStream);
            var result = streamReader.ReadToEnd();
            streamReader.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            return result;
        }

        public static string ToTripleDesEncryption(string input)
        {
            var rgbKey = ConvertToByte8Array(RgbKey24);
            var rgbIv = ConvertToByte8Array(RgbIv8);
            var tripleDesCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, tripleDesCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
            var streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(input);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            var result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            streamWriter.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();

            return result;
        }

        public static string ToTripleDesDecrypt(string input)
        {
            var rgbKey = ConvertToByte8Array(RgbKey24);
            var rgbIv = ConvertToByte8Array(RgbIv8);
            var tripleDesCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            var memoryStream = new MemoryStream(Convert.FromBase64String(input));
            var cryptoStream = new CryptoStream(memoryStream, tripleDesCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Read);
            var streamWriter = new StreamReader(cryptoStream);
            var result = streamWriter.ReadToEnd();
            streamWriter.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            return result;
        }

        public static string ToRc2Encryption(string input)
        {
            var rgbKey = ConvertToByte8Array(RgbKey8);
            var rgbIv = ConvertToByte8Array(RgbIv8);
            var rc2CryptoServiceProvider = new RC2CryptoServiceProvider();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, rc2CryptoServiceProvider.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
            var streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(input);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            var result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            streamWriter.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            return result;
        }

        public static string ToRc2Decrypt(string input)
        {
            var rgbKey = ConvertToByte8Array(RgbKey8);
            var rgbIv = ConvertToByte8Array(RgbIv8);
            var rc2CryptoServiceProvider = new RC2CryptoServiceProvider();
            var memoryStream = new MemoryStream(Convert.FromBase64String(input));
            var cryptoStream = new CryptoStream(memoryStream, rc2CryptoServiceProvider.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Read);
            var streamReader = new StreamReader(cryptoStream);
            var result = streamReader.ReadToEnd();
            streamReader.Dispose();
            cryptoStream.Dispose();
            memoryStream.Dispose();
            return result;
        }

        public static string ToTripleDesMd5Encryption(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            using var md5 = new MD5CryptoServiceProvider();
            var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(EncryptionKey));
            using var tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var transform = tripDes.CreateEncryptor();
            var results = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(results, 0, results.Length);
        }

        public static string ToTripleDesMd5Decrypt(string input)
        {
            var data = Convert.FromBase64String(input);
            using var md5 = new MD5CryptoServiceProvider();
            var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(EncryptionKey));
            using var tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var transform = tripDes.CreateDecryptor();
            var results = transform.TransformFinalBlock(data, 0, data.Length);
            return Encoding.UTF8.GetString(results);
        }

        private static byte[] ConvertToByteArray(string input)
        {
            var unicodeEncoding = new UnicodeEncoding();
            return unicodeEncoding.GetBytes(input);
        }

        private static byte[] ConvertToByte8Array(string input)
        {
            var charArray = input.ToCharArray();
            var byteArray = new byte[charArray.Length];
            for (var i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = Convert.ToByte(charArray[i]);
            }
            return byteArray;
        }
    }
}

