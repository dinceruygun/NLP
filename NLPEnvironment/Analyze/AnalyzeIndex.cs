using NLPEnvironment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Analyze
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class AnalyzeIndex
    {
        List<INlpAnalyzeIndex> _analyzeIndexCollection;
        int _lineNumber;
        int _wordNumber;
        int _sentenceNumber;


        public List<INlpAnalyzeIndex> AnalyzeIndexCollection
        {
            get
            {
                return _analyzeIndexCollection;
            }

            set
            {
                _analyzeIndexCollection = value;
            }
        }

        public int LineNumber
        {
            get
            {
                return _lineNumber;
            }

            set
            {
                _lineNumber = value;
            }
        }

        public int WordNumber
        {
            get
            {
                return _wordNumber;
            }

            set
            {
                _wordNumber = value;
            }
        }

        public int SentenceNumber
        {
            get
            {
                return _sentenceNumber;
            }

            set
            {
                _sentenceNumber = value;
            }
        }

        public AnalyzeIndex()
        {
            _analyzeIndexCollection = new List<INlpAnalyzeIndex>();
        }


        public override string ToString()
        {
            return string.Join(", ", _analyzeIndexCollection);
        }
    }
}
