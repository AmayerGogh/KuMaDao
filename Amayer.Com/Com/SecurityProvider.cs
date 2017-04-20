using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Com.Com
{
    class SecurityProvider
    {
        public static string Encrypt(string plainText, string key)
        {
            byte[] inputByteArray = ASCIIEncoding.UTF8.GetBytes(plainText);
            byte[] keyByteArray = ASCIIEncoding.UTF8.GetBytes(key);

            DES des = new DESCryptoServiceProvider();
            des.Key = keyByteArray;
            des.IV = keyByteArray;

            StringBuilder sBuilder = new StringBuilder();
            MemoryStream ms = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();

            byte[] outputByte = ms.ToArray();
            ms.Dispose();
            ms.Close();

            foreach (var item in outputByte)
            {
                sBuilder.AppendFormat("{0:x2}", item);
            }
            return sBuilder.ToString();
        }
        public static string Decrypt(string CypherText, string key)
        {
            byte[] keyByteArray = ASCIIEncoding.UTF8.GetBytes(key);
            DES des = new DESCryptoServiceProvider();
            des.Key = keyByteArray;
            des.IV = keyByteArray;

            int length = CypherText.Length / 2;
            byte[] inputByteArray = new byte[length];
            for (int i = 0; i < length; i++)
            {
                string subString = CypherText.Substring(i * 2, 2);
                inputByteArray[i] = Convert.ToByte(subString, 16);
            }
            MemoryStream ms = new MemoryStream();
            CryptoStream pryptoStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            pryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            pryptoStream.FlushFinalBlock();
            byte[] outputByteArray = ms.ToArray();
            ms.Dispose();
            ms.Close();
            return ASCIIEncoding.UTF8.GetString(outputByteArray);
        }

        #region 字符串MD5运算
        /// <summary>
        /// MD5算法
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns>返回MD5运算后的字符串</returns>
        public static string Md5Hash(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            MD5 md5 = MD5.Create();
            byte[] resultBytes = md5.ComputeHash(bytes);
            StringBuilder sbMd5 = new StringBuilder();
            for (int i = 0; i < resultBytes.Length; i++)
            {
                sbMd5.Append(resultBytes[i].ToString("x2"));
            }
            return sbMd5.ToString();
        }
        #endregion

        public static string GenerateCheckCode()
        {
            int number;
            char code;
            string checkCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();
                // if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
                //else
                //    code = (char)('a' + (char)(number % 26));
                checkCode += code.ToString();
            }
            //HttpContext.Current.Session.Add("CheckCode", checkCode);
            return checkCode;
        }
    }
}
