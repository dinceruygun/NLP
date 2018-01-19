using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class Line: TokenizerEntity
    {
        string _text;

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }

        public SentenceCollection SentenceList { get; set; }

        public Line()
        {

        }


        public Line(string text)
        {
            _text = text;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}
