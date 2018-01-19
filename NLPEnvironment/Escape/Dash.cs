using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Dash : EscapeCharacter
    {
        public Dash()
        {
            base.Escape = new char[] { '-' };
            base.Name = "DASH";
            base.Description = "Bir olayın başlangıç ve bitiş tarihleri arasına konur.";
        }

        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.DASH;
        }
    }
}
