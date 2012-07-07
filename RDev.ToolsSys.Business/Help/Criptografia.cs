using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RDev.ToolsSys.Business.Help
{
    public class Criptografia
    {
        const string PHRASE = "Cr!pt06R@f@r";
        const string S_TVALUE = "V@1u35Tr!n6";
        const string VECTOR = "@7t5n7Y4f6Q1v4K9";

        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be encrypted.
        /// </param>
        /// <returns>
        /// Encrypted value formatted as a base64-encoded string.
        /// </returns>
        public static string Criptografar(string plainText)
        {
            if (ConfigurationManager.AppSettings["CriptografiaEntrePaginas"] == "false")
                return plainText;

            const string PASS_PHRASE = PHRASE; // can be any string
            const string SALT_VALUE = S_TVALUE; // can be any string
            const string HASH_ALGORITHM = "SHA1"; // can be "MD5"
            const int PASSWORD_ITERATIONS = 2; // can be any number
            const int KEY_SIZE = 256; // can be 192 or 128
            const string INIT_VECTOR = VECTOR; // must be 16 bytes

            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                PASS_PHRASE,
                saltValueBytes,
                HASH_ALGORITHM,
                PASSWORD_ITERATIONS);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                keyBytes,
                initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            //string cipherText = Convert.ToBase64String(cipherTextBytes);
            string cipherText = CriptografarParaHexadecimal(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }

        /// <summary>
        /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        /// </summary>
        /// <param name="cipherText">
        /// Base64-formatted ciphertext value.
        /// </param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        /// <remarks>
        /// Most of the logic in this function is similar to the Encrypt
        /// logic. In order for decryption to work, all parameters of this function
        /// - except cipherText value - must match the corresponding parameters of
        /// the Encrypt function which was called to generate the
        /// ciphertext.
        /// </remarks>
        public static string Descriptografar(string cipherText)
        {
            if (ConfigurationManager.AppSettings["CriptografiaEntrePaginas"] == "false" ||
                string.IsNullOrEmpty(cipherText))
                return cipherText;

            const string PASS_PHRASE = PHRASE; // can be any string
            const string SALT_VALUE = S_TVALUE; // can be any string
            const string HASH_ALGORITHM = "SHA1"; // can be "MD5"
            const int PASSWORD_ITERATIONS = 2; // can be any number
            const int KEY_SIZE = 256; // can be 192 or 128
            const string INIT_VECTOR = VECTOR; // must be 16 bytes

            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(INIT_VECTOR);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SALT_VALUE);

            // Convert our ciphertext into a byte array.
            //byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            byte[] cipherTextBytes = DescriptografarDeHexadecimal(cipherText);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                PASS_PHRASE,
                saltValueBytes,
                HASH_ALGORITHM,
                PASSWORD_ITERATIONS);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(KEY_SIZE / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                keyBytes,
                initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         decryptor,
                                                         CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;
        }

        /// <summary>
        /// Método malandro do Ivan
        /// </summary>
        internal static string CriptografarParaHexadecimal(byte[] texto)
        {
            var stringBuilder = new StringBuilder();

            foreach (byte t in texto)
                stringBuilder.AppendFormat("{0:X2}", t);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Método malandro do Ivan
        /// </summary>
        /// <returns></returns>
        internal static byte[] DescriptografarDeHexadecimal(string textoHexadecimal)
        {
            var raw = new byte[textoHexadecimal.Length / 2];

            for (var i = 0; i < raw.Length; i++)
                raw[i] = Convert.ToByte(textoHexadecimal.Substring(i * 2, 2), 16);

            return raw;
        }
    }
}
