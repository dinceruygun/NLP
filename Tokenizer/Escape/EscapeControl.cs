using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Extention;

namespace Tokenizer.Escape
{
    public class EscapeControl
    {
        public Dictionary<int, EscapeItem> CheckEscape(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            if (text == "") return null;


            var result = new Dictionary<int, EscapeItem>();


            foreach (var escape in EscapeFactory.EscapeCharacters)
            {
                foreach (var index in text.AllIndexesOf(escape.Escape))
                {
                    var type = escape.TypeControl(text, index);

                    result.Add(index, new EscapeItem()
                    {
                        Index = index,
                        EscapeType = type,
                        EscapeCharacter = escape
                    });
                }
            }



            return result;
        }
    }
}
