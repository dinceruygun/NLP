using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class Sentence
    {
        Line _line;
        string _text;

        public Line Line
        {
            get
            {
                return _line;
            }

            set
            {
                _line = value;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }

            internal set
            {
                _text = value;
            }
        }

        public WordCollection WordList { get; set; }

        public Sentence()
        {

        }


        public Sentence(Line line, string text)
        {
            this._line = line;
            this._text = text;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}
