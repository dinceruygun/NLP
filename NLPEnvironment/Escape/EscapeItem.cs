using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class EscapeItem
    {
        public EscapeCharacter EscapeCharacter { get; set; }
        public EscapeType EscapeType { get; set; }
        public int Index { get; set; }



        public override string ToString()
        {
            return $"[{EscapeCharacter?.Name}][{EscapeType}][index={Index}]";
        }
    }
}
