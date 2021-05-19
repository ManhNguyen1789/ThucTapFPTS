using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Test.Areas.Admin.code
{
    public class PassMd5
    {
        /// <summary>
        /// Hàm mã hóa md5 cho login admin, tên class PassMd5
        /// </summary>
        /// <param name="input">input là mật khẩu được nhập từ textbox</param>
        /// <returns>trả về mật khẩu đã được mã hóa</returns>
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}