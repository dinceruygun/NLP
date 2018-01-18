using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Entities
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

            internal set
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
