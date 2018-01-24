using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPExtention
{
    public static class WordTools
    {
        static Dictionary<string, int> _alphabe;

        public static Dictionary<string, int> Alphabe
        {
            get
            {
                if (_alphabe == null)
                {
                    _alphabe = new Dictionary<string, int>();

                    _alphabe.Add("a", 1);
                    _alphabe.Add("b", 2);
                    _alphabe.Add("c", 3);
                    _alphabe.Add("ç", 4);
                    _alphabe.Add("d", 5);
                    _alphabe.Add("e", 6);
                    _alphabe.Add("f", 7);
                    _alphabe.Add("g", 8);
                    _alphabe.Add("ğ", 9);
                    _alphabe.Add("h", 10);
                    _alphabe.Add("ı", 11);
                    _alphabe.Add("i", 12);
                    _alphabe.Add("j", 13);
                    _alphabe.Add("k", 14);
                    _alphabe.Add("l", 15);
                    _alphabe.Add("m", 16);
                    _alphabe.Add("n", 17);
                    _alphabe.Add("o", 18);
                    _alphabe.Add("ö", 19);
                    _alphabe.Add("p", 20);
                    _alphabe.Add("r", 21);
                    _alphabe.Add("s", 22);
                    _alphabe.Add("ş", 23);
                    _alphabe.Add("t", 24);
                    _alphabe.Add("u", 25);
                    _alphabe.Add("ü", 26);
                    _alphabe.Add("v", 27);
                    _alphabe.Add("y", 28);
                    _alphabe.Add("z", 29);
                }

                return _alphabe;
            }
        }

        public static int[] TextToNumeric(this string text)
        {
            var result = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                var t = text[i].ToString().ToLower(new CultureInfo("tr-TR", false));
                result[i] = Alphabe.ContainsKey(t) ? Alphabe[t] : 0;
            }

            return result;
        }
    }
}
