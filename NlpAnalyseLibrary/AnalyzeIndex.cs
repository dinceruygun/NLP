using NLPEnvironment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlpAnalyseLibrary
{
    public class AnalyzeIndex
    {
        public List<INlpAnalyzeIndex> AnalyzeIndexCollection { get; set; }
        public int LineNumber { get; set; }
        public int WordNumber { get; set; }
    }
}
