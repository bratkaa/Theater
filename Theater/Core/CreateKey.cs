using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Core
{
    internal class CreateKey
    {
        public static string Generate(string login, string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(login + ".*(spliter)*." + password);
            string res = Convert.ToBase64String(bytes);
            return res;
        }

        public static string GetDataFromKey(string key) 
        {
            byte[] b = Convert.FromBase64String(key);
            return Encoding.UTF8.GetString(b);
        }
    }
}
