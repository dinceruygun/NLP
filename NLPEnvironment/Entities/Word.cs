using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class Word
    {
        string _text;
        int _length;

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
                _length = _text.Length;
            }
        }

        public SyllableCollection Syllable { get; set; }
        public Word Root { get; set; }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public Word()
        {

        }


        public Word(string text)
        {
            _text = text;
            _length = _text.Length;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}
