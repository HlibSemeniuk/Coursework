using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class DataHandler
    {
        public static void ToCorrect(ref string data)
        {
            string temp = "";

            for (int i = 1; i < data.Length; i++)
            {
                temp += char.ToLower(data[i]);
            }

            data = char.ToUpper(data[0]) + temp;
        }
    }
}
