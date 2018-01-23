﻿using System;
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

        public SyllableCollection Syllable { get; set; }
        public Word Root { get; set; }

        public Word()
        {

        }


        public Word(string text)
        {
            _text = text;
        }


        public override string ToString()
        {
            return Text;
        }
    }
}