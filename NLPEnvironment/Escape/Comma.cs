using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Comma : EscapeCharacter
    {
        public Comma()
        {
            base.Escape = new char[] { ',' };
            base.Name = "COMMA";
            base.Description = "Yazıda sıralanan eş görevli sözcükler ya da söz gruplarını ayırmada kullanılır";
        }

        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.NONE;
        }
    }
}
