﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Entities
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class Syllable
    {
        string _text;

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
