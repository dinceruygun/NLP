using NLPEnvironment.Entities;
using NLPExtention;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


    public class SimilarWordResult
    {
        public List<SimilarWord> WordList = new List<SimilarWord>();
        public TimeSpan PassingTime { get; set; }
        public Word SelectWord { get; set; }
    }


    public class MorphologicalManager
    {

        private int similarRate = 30;

        public SimilarWordResult SimilarWords(Word word)
        {


            if (word == null) return null;
            if (string.IsNullOrEmpty(word.Text)) return null;
            if (word.Text.Length < 3) return null;




            var sw = Stopwatch.StartNew();

            var result = new SimilarWordResult();






            Parallel.ForEach(MorphologicalCollection.WordIndexList, collection =>
            {
                if (word.Length >= collection.Key - (similarRate / 10) && word.Length <= collection.Key + (similarRate / 10))
                {
                    foreach (var item in collection.Value)
                    {
                        var distance = LevenshteinDistance.Compute(item.Text, word.Text);

                        if ((distance * 100) / (word.Text.Length - 1) < similarRate)
                        {
                            result.WordList.Add(new SimilarWord
                            {
                                Similar = item,
                                Distance = distance
                            });
                        }
                    }
                }
            });





            if (result.WordList.Count == 0) return null;



            if (result.WordList.Count == 1)
            {
                result.SelectWord = result.WordList[0].Similar;
            }
            else
            {


                var minDistance = result.WordList.OrderBy(w => w.Distance).First().Distance;
                var selectWords = result.WordList.Where(w => w.Distance == minDistance);

                var wordNumeric = word.Text.TextToNumeric();

                var wordNumericGroup = wordNumeric.GroupBy(x => x)
                                                    .OrderByDescending(x => x.Count())
                                                    .Select(x => x.Key)
                                                    .ToList();

                foreach (var item in selectWords)
                {
                    var n = item.Similar.Text.TextToNumeric();

                    var ng = n.GroupBy(x => x)
                                .OrderByDescending(x => x.Count())
                                .Select(x => x.Key)
                                .ToList();

                    if (wordNumericGroup.SequenceEqual(ng))
                    {
                        result.SelectWord = item.Similar;
                    }

                }
            }



            sw.Stop();
            result.PassingTime = sw.Elapsed;

            return result;
        }


    }
}
