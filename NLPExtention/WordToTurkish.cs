using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NLPExtention
{
    public static class WordToTurkish
    {
        private static string asciiString;
        private static string turkishString;
        static int turkishContextSize = 10;


        private static Dictionary<string, Dictionary<string, int>> _turkishPattern;



        static Dictionary<string, string> _turkishCharacters;
        public static Dictionary<string, string> TurkishCharacters
        {
            get
            {
                if (_turkishCharacters == null)
                {
                    _turkishCharacters = new Dictionary<string, string>();

                    _turkishCharacters.Add("ş", "s");
                    _turkishCharacters.Add("Ş", "S");
                    _turkishCharacters.Add("ı", "i");
                    _turkishCharacters.Add("İ", "I");
                    _turkishCharacters.Add("ğ", "g");
                    _turkishCharacters.Add("Ğ", "g");
                    _turkishCharacters.Add("ç", "c");
                    _turkishCharacters.Add("Ç", "c");
                    _turkishCharacters.Add("ö", "o");
                    _turkishCharacters.Add("Ö", "o");
                }

                return _turkishCharacters;
            }
        }



        static Dictionary<string, string> _turkishDowncaseAsciifyTable;
        public static Dictionary<string, string> TurkishDowncaseAsciifyTable
        {
            get
            {
                if (_turkishDowncaseAsciifyTable == null)
                {
                    _turkishDowncaseAsciifyTable = new Dictionary<string, string>();

                    foreach (var letter in uppercaseLetters)
                    {
                        _turkishDowncaseAsciifyTable.Add(letter, letter.ToLower(CultureInfo.GetCultureInfo("en-GB")));
                        _turkishDowncaseAsciifyTable.Add(letter.ToLower(CultureInfo.GetCultureInfo("en-GB")), letter.ToLower(CultureInfo.GetCultureInfo("en-GB")));
                    }


                    _turkishDowncaseAsciifyTable.Add("ç", "c");
                    _turkishDowncaseAsciifyTable.Add("Ç", "c");
                    _turkishDowncaseAsciifyTable.Add("ğ", "g");
                    _turkishDowncaseAsciifyTable.Add("Ğ", "g");
                    _turkishDowncaseAsciifyTable.Add("ö", "o");
                    _turkishDowncaseAsciifyTable.Add("Ö", "o");
                    _turkishDowncaseAsciifyTable.Add("ı", "i");
                    _turkishDowncaseAsciifyTable.Add("İ", "i");
                    _turkishDowncaseAsciifyTable.Add("ş", "s");
                    _turkishDowncaseAsciifyTable.Add("Ş", "s");
                    _turkishDowncaseAsciifyTable.Add("ü", "u");
                    _turkishDowncaseAsciifyTable.Add("Ü", "u");
                }

                return _turkishDowncaseAsciifyTable;
            }
        }






        static Dictionary<string, string> _turkishUpcaseAccentsTable;
        public static Dictionary<string, string> TurkishUpcaseAccentsTable
        {
            get
            {
                if (_turkishUpcaseAccentsTable == null)
                {
                    _turkishUpcaseAccentsTable = new Dictionary<string, string>();

                    foreach (var letter in uppercaseLetters)
                    {
                        _turkishUpcaseAccentsTable.Add(letter, letter.ToLower(CultureInfo.GetCultureInfo("en-GB")));
                        _turkishUpcaseAccentsTable.Add(letter.ToLower(CultureInfo.GetCultureInfo("en-GB")), letter.ToLower(CultureInfo.GetCultureInfo("en-GB")));
                    }


                    _turkishUpcaseAccentsTable.Add("ç", "C");
                    _turkishUpcaseAccentsTable.Add("Ç", "C");
                    _turkishUpcaseAccentsTable.Add("ğ", "G");
                    _turkishUpcaseAccentsTable.Add("Ğ", "G");
                    _turkishUpcaseAccentsTable.Add("ö", "O");
                    _turkishUpcaseAccentsTable.Add("Ö", "O");
                    _turkishUpcaseAccentsTable.Add("ı", "I");
                    _turkishUpcaseAccentsTable.Add("İ", "i");
                    _turkishUpcaseAccentsTable.Add("ş", "S");
                    _turkishUpcaseAccentsTable.Add("Ş", "S");
                    _turkishUpcaseAccentsTable.Add("ü", "U");
                    _turkishUpcaseAccentsTable.Add("Ü", "U");
                }

                return _turkishUpcaseAccentsTable;
            }
        }






        static Dictionary<string, string> _turkishToggleAccentTable;
        public static Dictionary<string, string> TurkishToggleAccentTable
        {
            get
            {
                if (_turkishToggleAccentTable == null)
                {
                    _turkishToggleAccentTable = new Dictionary<string, string>();

                    _turkishToggleAccentTable.Add("c", "ç");
                    _turkishToggleAccentTable.Add("C", "Ç");
                    _turkishToggleAccentTable.Add("g", "ğ");
                    _turkishToggleAccentTable.Add("G", "Ğ");
                    _turkishToggleAccentTable.Add("o", "ö");
                    _turkishToggleAccentTable.Add("O", "Ö");
                    _turkishToggleAccentTable.Add("u", "ü");
                    _turkishToggleAccentTable.Add("U", "Ü");
                    _turkishToggleAccentTable.Add("i", "ı");
                    _turkishToggleAccentTable.Add("I", "İ");
                    _turkishToggleAccentTable.Add("s", "ş");
                    _turkishToggleAccentTable.Add("S", "Ş");
                    _turkishToggleAccentTable.Add("ç", "c"); 
                    _turkishToggleAccentTable.Add("Ç", "C");
                    _turkishToggleAccentTable.Add("ğ", "g");
                    _turkishToggleAccentTable.Add("Ğ", "G");
                    _turkishToggleAccentTable.Add("ö", "o");
                    _turkishToggleAccentTable.Add("Ö", "O");
                    _turkishToggleAccentTable.Add("ü", "u");
                    _turkishToggleAccentTable.Add("Ü", "U");
                    _turkishToggleAccentTable.Add("ı", "i");
                    _turkishToggleAccentTable.Add("İ", "I");
                    _turkishToggleAccentTable.Add("ş", "s");
                    _turkishToggleAccentTable.Add("Ş", "S");
                }

                return _turkishToggleAccentTable;
            }
        }






        public static Dictionary<string, Dictionary<string, int>> TurkishPattern
        {
            get
            {
                if (_turkishPattern == null)
                {
                    _turkishPattern = new Dictionary<string, Dictionary<string, int>>();

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    TextReader inputStream = new StreamReader(assembly.GetManifestResourceStream("NLPExtention.Container.TurkishPattern.txt"));
                    string result = inputStream.ReadToEnd();


                    dynamic json = JObject.Parse(result);

                    var c = json.c;
                    var g = json.g;
                    var o = json.o;
                    var s = json.s;
                    var u = json.u;
                    var i = json.i;


                    var cList = new Dictionary<string, int>();
                    var gList = new Dictionary<string, int>();
                    var oList = new Dictionary<string, int>();
                    var sList = new Dictionary<string, int>();
                    var uList = new Dictionary<string, int>();
                    var iList = new Dictionary<string, int>();

                    foreach (var item in c)
                    {
                        cList.Add((item.Name as string), (int.Parse(item.Value.Value.ToString())));
                    }

                    foreach (var item in g)
                    {
                        gList.Add((item.Name as string), (int.Parse(item.Value.Value.ToString())));
                    }

                    foreach (var item in o)
                    {
                        oList.Add((item.Name as string), (int.Parse(item.Value.Value.ToString())));
                    }

                    foreach (var item in s)
                    {
                        sList.Add((item.Name as string), (int.Parse(item.Value.Value.ToString())));
                    }

                    foreach (var item in u)
                    {
                        uList.Add((item.Name as string), (int.Parse(item.Value.Value.ToString())));
                    }

                    foreach (var item in i)
                    {
                        iList.Add((item.Name as string), (int.Parse(item.Value.Value.ToString())));
                    }


                    _turkishPattern.Add("c", cList);
                    _turkishPattern.Add("g", gList);
                    _turkishPattern.Add("o", oList);
                    _turkishPattern.Add("s", sList);
                    _turkishPattern.Add("u", uList);
                    _turkishPattern.Add("i", iList);
                }

                return _turkishPattern;
            }
        }






        static string[] uppercaseLetters = { "A", "B", "C", "D", "E", "F", "G",
            "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z" };





        



        static WordToTurkish()
        {
            

        }




        private static string setCharAt(string mystr, int pos, string c)
        {
            return string.Concat(mystr.Substring(0, pos), c, mystr.Substring(pos + 1, mystr.Length - (pos + 1)));
        }


        private static string turkishToggleAccent(string c)
        {
            string result = TurkishToggleAccentTable[c];
            return (result == null) ? c : result;
        }


        private static string repeatString(string haystack, int times)
        {
            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < times; i++)
                tmp.Append(haystack);

            return tmp.ToString();
        }



        private static bool turkishMatchPattern(Dictionary<string, int> dlist, int point)
        {
            int rank = dlist.Count * 2;
            string str = turkishGetContext(turkishContextSize, point);

            int start = 0;
            int end = 0;
            int _len = str.Length;

            while (start <= turkishContextSize)
            {
                end = turkishContextSize;
                while (end <= _len)
                {
                    string s = str.Substring(start, end - start);

                    int r = 0;
                    var control = dlist.TryGetValue(s, out r);


                    if (control && Math.Abs(r) < Math.Abs(rank))
                    {
                        rank = r;
                    }
                    end++;
                }
                start++;
            }
            return rank > 0;
        }



        private static bool turkishMatchPattern(Dictionary<string, int> dlist)
        {
            return turkishMatchPattern(dlist, 0);
        }


        private static string turkishGetContext(int size, int point)
        {
            string s = repeatString(" ", (1 + (2 * size)));
            s = setCharAt(s, size, "X");

            int i = size + 1;
            bool space = false;
            int index = point;
            index++;

            string currentChar;

            while (i < s.Length && !space && index < asciiString.Length)
            {
                currentChar = turkishString[index].ToString();

                string x = TurkishDowncaseAsciifyTable.ContainsKey(currentChar) ? TurkishDowncaseAsciifyTable[currentChar] : null;

                if (x == null)
                {
                    if (!space)
                    {
                        i++;
                        space = true;
                    }
                }
                else
                {
                    s = setCharAt(s, i, x);
                    i++;
                    space = false;
                }
                index++;
            }

            s = s.Substring(0, i);

            index = point;
            i = size - 1;
            space = false;

            index--;

            while (i >= 0 && index >= 0)
            {
                currentChar = turkishString[index].ToString();
                string x = TurkishUpcaseAccentsTable.ContainsKey(currentChar) ? TurkishUpcaseAccentsTable[currentChar] : null;

                if (x == null)
                {
                    if (!space)
                    {
                        i--;
                        space = true;
                    }
                }
                else
                {
                    s
                            = setCharAt(s, i, x);
                    i--;
                    space = false;
                }
                index--;
            }

            return s;
        }






        private static bool turkishNeedCorrection(string c, int point)
        {
            string ch = c;

            string tr = TurkishDowncaseAsciifyTable.ContainsKey(ch) ? TurkishDowncaseAsciifyTable[ch] : null;
            if (tr == null)
                tr = ch;

            Dictionary<string, int> pl = TurkishPattern.ContainsKey(tr.ToLower(CultureInfo.GetCultureInfo("en-GB"))) ? TurkishPattern[tr.ToLower(CultureInfo.GetCultureInfo("en-GB"))] : null;

            bool m = false;
            if (pl != null)
            {
                m = turkishMatchPattern(pl, point);
            }

            if (tr.Equals("I"))
            {
                if (ch.Equals(tr))
                {
                    return !m;
                }
                else
                {
                    return m;
                }
            }
            else
            {
                if (ch.Equals(tr))
                {
                    return m;
                }
                else
                {
                    return !m;
                }
            }
        }



        public static string ToTurkish(this string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            if (text.Trim() == "") return null;
            if (text.IndexOf(" ") > 0) return null;


            turkishString = text;
            asciiString = text;

            for (int i = 0; i < turkishString.Length; i++)
            {
                string c = turkishString[i].ToString();

                if (turkishNeedCorrection(c, i))
                {
                    turkishString = setCharAt(turkishString, i,
                            turkishToggleAccent(c));
                }
                else
                {
                    turkishString = setCharAt(turkishString, i, c);
                }
            }
            return turkishString;
        }




    }
}
