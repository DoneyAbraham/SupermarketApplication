using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SuperMarketApplication.Data.Helpers
{
    public static class EncryptionHelper
    {
        public static string EncryptPassword(string plainText)
        {
            //if (plainText == null) throw new ArgumentNullException("plainText");

            ////encrypt data
            //var data = Encoding.Unicode.GetBytes(plainText);
            //byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);

            ////return as base64 string
            //return Convert.ToBase64String(encrypted);

            using (var md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash. 
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // Create a new Stringbuilder to collect the bytes 
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data  
                // and format each one as a hexadecimal string. 
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string. 
                return sBuilder.ToString();
            }
        }
    }
}
