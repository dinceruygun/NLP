using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{

    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public abstract class ISyllableType
    {
        public string Text { get; set; }



        public override string ToString()
        {
            return Text;
        }
    }
}
