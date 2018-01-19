using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Brackets : EscapeCharacter
    {
        public Brackets()
        {
            base.Escape = new char[] { '\'', '’' };
            base.Name = "BRACKETS";
            base.Description = "Özel adlardan sonra gelen çekim eklerini ayırmada kullanılır";
        }

        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.BRACKETS;
        }
    }
}
