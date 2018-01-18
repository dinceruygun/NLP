using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer
{
    public class TokenizerManager
    {
        private string _baseText;

        public TokenizerManager(string Text)
        {
            this._baseText = Text;
        }

        public string BaseText
        {
            get
            {
                return _baseText;
            }
        }





        public void Parse(string Text)
        {
            this._baseText = Text;
            this.Parse();
        }

        public void Parse()
        {
            if (string.IsNullOrEmpty(BaseText)) return;

            var lineParser = new Parser.Line(BaseText);
            var lines = lineParser.Parse();
        }

    }
}
