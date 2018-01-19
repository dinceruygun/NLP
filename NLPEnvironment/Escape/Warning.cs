using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Warning : EscapeCharacter
    {
        public Warning()
        {
            base.Escape = new char[] { '!' };
            base.Name = "WARNING";
            base.Description = "Şaşma , korku, kızma ,heyecan,sevinme… gibi duyguları dile getiren cümlelerin sonunda kullanılır";
        }

        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.WARNING;
        }
    }
}
