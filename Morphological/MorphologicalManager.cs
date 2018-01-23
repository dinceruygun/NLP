using NLPEnvironment.Entities;
using NLPExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphological
{

    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class SimilarWord
    {
        public int Distance { get; set; }
        public Word Similar { get; set; }


        public override string ToString()
        {
            return $"{Similar.Text}, {Distance}";
        }
    }


    public class MorphologicalManager
    {

        private int similarRate = 30;

        public List<SimilarWord> WordCompare(Word word)
        {
            if (word == null) return null;
            if (string.IsNullOrEmpty(word.Text)) return null;
            if (word.Text.Length < 3) return null;


            var result = new List<SimilarWord>();


            foreach (var item in MorphologicalCollection.WordList)
            {
                var distance = LevenshteinDistance.Compute(item.Text, word.Text);

                if ((distance * 100) / (word.Text.Length - 1) < similarRate)
                {
                    result.Add(new SimilarWord {
                        Similar = item,
                        Distance = distance
                    });
                }
            }


            return result.OrderBy(r=>r.Distance).ToList();
        }


    }
}
