using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class Syllable
    {
        string _text;
        public ISyllableType SyllableType { get; set; }


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

        public Syllable()
        {
               
        }


        public Syllable(string text)
        {
            _text = text;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}
