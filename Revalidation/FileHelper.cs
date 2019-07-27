using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Revalidation
{
    public class FileHelper
    {
        /// <summary> 计算文件MD5值 </summary>
        /// FileStream stream = File.Open(filePath, FileMode.Open)
        public static string ComputeFileMD5(Stream stream)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(stream);
            byte[] bytes = md5.Hash;
            md5.Clear();
            StringBuilder sb = new StringBuilder(32);
            foreach (var by in bytes)
            {
                sb.Append(by.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
