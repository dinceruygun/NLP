﻿using NLPEnvironment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Interfaces
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public abstract class INlpAnalyzeIndex
    {
        public Word AddressWord { get; set; }
        public Dictionary<string, string> AttributeList { get; set; }
        public string Text { get; set; }


        public override string ToString()
        {
            return this.Text;
        }
    }
}
