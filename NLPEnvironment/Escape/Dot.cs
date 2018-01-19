using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public class Dot : EscapeCharacter
    {

        public Dot()
        {
            base.Escape = new char[] { '.' };
            base.Name = "DOT";
            base.Description = "Cümle sonunda, kısaltmada, tarih ve saatlerde kullanılır";
        }


        public override EscapeType TypeControl(string text, int index)
        {
            if (text.Length - 1 == index) return EscapeType.END;


            var shortList = new WordShort();

            var word = text.Substring(text.Substring(0, index).LastIndexOf(' ') < 0 ? 0 : text.Substring(0, index).LastIndexOf(' '), index - text.Substring(0, index).LastIndexOf(' ')).Trim();
            word = word.Replace("İ", "i");
            if (shortList.ShortList.ContainsKey(word.ToLower())) return EscapeType.SHORT;


            if (index > 0)
            {
                int i;
                if (int.TryParse(text.Substring(index - 1, 1), out i)) return EscapeType.NUMERIC;
            }


            if (text[index + 1] == ' ') return EscapeType.END;
            if (text[index + 1] == '\"'
                || text[index + 1] == '’'
                || text[index + 1] == '\''
                || text[index + 1] == '”'
                ) return EscapeType.TALKEND;


            return EscapeType.NONE;
        }
    }
}
