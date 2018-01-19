using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Question : EscapeCharacter
    {
        public Question()
        {
            base.Escape = new char[] { '?' };
            base.Name = "QUESTION";
            base.Description = "Soru bildiren cümle veya sözcüklerin sonunda kullanılır, cümle sözde soru cümlesi de olsa yani karşıdan bir cevap beklenmese de cümlenin sonuna soru işareti konur.";
        }

        public override EscapeType TypeControl(string text, int index)
        {
            return EscapeType.QUESTION;
        }
    }
}
