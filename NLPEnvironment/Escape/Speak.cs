using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Speak : EscapeCharacter
    {
        public Speak()
        {
            base.Escape = new char[] { '\"', '“', '”' };
            base.Name = "SPEAK";
            base.Description = "Aktarma söz ya da cümleler tırnak içinde gösterilebilir";
        }

        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.SPEAK;
        }
    }
}
