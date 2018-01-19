using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Colon : EscapeCharacter
    {
        public Colon()
        {
            base.Escape = new char[] { ':' };
            base.Name = "COLON";
            base.Description = "Bir cümle veya sözcükten sonra yapılacak açıklamalardan önce kullanılır";
        }


        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.COLON;
        }
    }
}
