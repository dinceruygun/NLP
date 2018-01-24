using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
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
}
