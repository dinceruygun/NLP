using NLPEnvironment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Entities;
using LuceneLibrary;
using System.Data;
using NLPEnvironment.Analyze;

namespace NlpAnalyseAddress
{
    public class AnalyseAddress : INlpAnalyse
    {
        LuceneManager manager;


        public override void Analyse(LineCollection lines)
        {
            if (lines == null) return;


            manager = new LuceneManager();
            if (!manager.ExistSchema("address")) manager.AddSchema("address");



            var analyzeIndexList = new List<AnalyzeIndex>();


            foreach (var line in lines)
            {
                foreach (var sentence in line.SentenceList)
                {
                    foreach (var word in sentence.WordList)
                    {
                        if (word.SpellWord != null)
                        {
                            if (word.SpellWord.Root != null)
                            {

                                var adresList = AddressControl(word);

                                if (adresList.Count > 0)
                                {
                                    var analyze = new AnalyzeIndex();

                                    analyze.AnalyzeIndexCollection.AddRange(adresList);
                                    analyze.LineNumber = lines.IndexOf(line);
                                    analyze.WordNumber = sentence.WordList.IndexOf(word);
                                    analyze.SentenceNumber = line.SentenceList.IndexOf(sentence);


                                    analyzeIndexList.Add(analyze);
                                }
                            }
                        }
                    }
                }
            }




            ClearAddressIndex(ref analyzeIndexList, lines);



        }




        private void ClearAddressIndex(ref List<AnalyzeIndex> analyzeIndexList, LineCollection lines)
        {
            if (analyzeIndexList == null) return;

            foreach (var index in analyzeIndexList)
            {
                foreach (var analyze in index.AnalyzeIndexCollection)
                {
                    var address = (analyze as AddressItem);

                    var addressControl = AddressControlFactory.GetControl(address.AddressType);

                    if (addressControl != null)
                    {
                        bool c = addressControl.Control(analyze, lines, index);
                    }
                }
            }
        }




        private List<AddressItem> AddressControl(Word word)
        {

            if (word == null) return null;

            var result = new List<AddressItem>();


            var equalCountry = manager.Query("address", "ulkeler", word.SpellWord.Root.Text);
            var equalCity = manager.Query("address", "sehirler", word.SpellWord.Root.Text);
            var equalDistrict = manager.Query("address", "ilceler", word.SpellWord.Root.Text);
            var equalNeighborhood = manager.Query("address", "semtmahalle", word.SpellWord.Root.Text);



            var a1 = AddressTableToList(equalCountry, "ulkeler", word);
            var a2 = AddressTableToList(equalCity, "sehirler", word);
            var a3 = AddressTableToList(equalDistrict, "ilceler", word);
            var a4 = AddressTableToList(equalNeighborhood, "semtmahalle", word);

            if (a1 != null) result.AddRange(a1);
            if (a2 != null) result.AddRange(a2);
            if (a3 != null) result.AddRange(a3);
            if (a4 != null) result.AddRange(a4);




            return result;
        }
        


        private List<AddressItem> AddressTableToList(DataTable table, string adressTypeText, Word word)
        {
            if (table == null) return null;
            if (table.Rows.Count == 0) return null;


            var result = new List<AddressItem>();
            var addressType = AddressTypeEnum.NONE;
            var textName = "";

            switch (adressTypeText)
            {
                case "ulkeler":
                    addressType = AddressTypeEnum.CITY;
                    textName = "ulkeadi";
                    break;
                case "sehirler":
                    addressType = AddressTypeEnum.CITY;
                    textName = "sehiradi";
                    break;
                case "ilceler":
                    addressType = AddressTypeEnum.PROVINCE;
                    textName = "ilceadi";
                    break;
                case "semtmahalle":
                    addressType = AddressTypeEnum.DISTRICT;
                    textName = "mahalleadi";
                    break;
            }


            foreach (DataRow row in table.Rows)
            {

                var attList = table.Columns.Cast<DataColumn>().Select(c => new KeyValuePair<string, string>(c.ColumnName, row[c].ToString())).ToDictionary(x => x.Key, x => x.Value);


                var addressItem = new AddressItem()
                {
                    AddressType = addressType,
                    AddressWord = word,
                    Text = row[textName].ToString(),
                    AttributeList = attList
                };



                result.Add(addressItem);
            }


            return result;
        }

    }
}
