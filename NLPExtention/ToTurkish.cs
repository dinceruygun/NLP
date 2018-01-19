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
    public static class ToTurkish
    {
        private static string asciiString;
        private static string turkishString;

        private static Dictionary<string, Dictionary<string, int?>> _turkishPattern;



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
                        _turkishDowncaseAsciifyTable.Add(letter, letter.ToLower(CultureInfo.CurrentCulture));
                        _turkishDowncaseAsciifyTable.Add(letter.ToLower(CultureInfo.CurrentCulture), letter.ToLower(CultureInfo.CurrentCulture));
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
                        _turkishUpcaseAccentsTable.Add(letter, letter.ToLower(CultureInfo.CurrentCulture));
                        _turkishUpcaseAccentsTable.Add(letter.ToLower(CultureInfo.CurrentCulture), letter.ToLower(CultureInfo.CurrentCulture));
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

                    _turkishToggleAccentTable.Add("c", "ç"); // initial direction
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
                    _turkishToggleAccentTable.Add("ç", "c"); // other direction
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






        public static Dictionary<string, Dictionary<string, int?>> TurkishPattern
        {
            get
            {
                if (_turkishPattern == null)
                {
                    _turkishPattern = new Dictionary<string, Dictionary<string, int?>>();

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


                    var cList = new Dictionary<string, int?>();
                    var gList = new Dictionary<string, int?>();
                    var oList = new Dictionary<string, int?>();
                    var sList = new Dictionary<string, int?>();
                    var uList = new Dictionary<string, int?>();
                    var iList = new Dictionary<string, int?>();

                    foreach (var item in c)
                    {
                        cList.Add((item.Name as string), (item.Value.Value as int?));
                    }

                    foreach (var item in g)
                    {
                        gList.Add((item.Name as string), (item.Value.Value as int?));
                    }

                    foreach (var item in o)
                    {
                        oList.Add((item.Name as string), (item.Value.Value as int?));
                    }

                    foreach (var item in s)
                    {
                        sList.Add((item.Name as string), (item.Value.Value as int?));
                    }

                    foreach (var item in u)
                    {
                        uList.Add((item.Name as string), (item.Value.Value as int?));
                    }

                    foreach (var item in i)
                    {
                        iList.Add((item.Name as string), (item.Value.Value as int?));
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





        



        static ToTurkish()
        {
            

        }



    }
}
