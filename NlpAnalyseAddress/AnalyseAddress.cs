using NLPEnvironment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Entities;
using LuceneLibrary;
using System.Data;

namespace NlpAnalyseAddress
{
    public class AnalyseAddress : INlpAnalyse
    {
        public override void Analyse(LineCollection lines)
        {
            if (lines == null) return;


            var manager = new LuceneManager();
            if (!manager.ExistSchema("address")) manager.AddSchema("address");


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
                                var equalCountry =  manager.Query("address", "ulkeler", word.SpellWord.Root.Text);
                                var equalCity = manager.Query("address", "sehirler", word.SpellWord.Root.Text);
                                var equalDistrict = manager.Query("address", "ilceler", word.SpellWord.Root.Text);
                                var equalNeighborhood = manager.Query("address", "semtmahalle", word.SpellWord.Root.Text);
                                


                            }
                        }
                    }
                }
            }
        }



        


    }
}
