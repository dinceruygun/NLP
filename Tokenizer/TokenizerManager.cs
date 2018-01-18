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

            var lineParser = new Parser.Line();
            var sentenceParser = new Parser.Sentence();
            var wordParser = new Parser.Word();



            var lines = lineParser.Parse(BaseText);

            foreach (var line in lines)
            {
                line.SentenceList = sentenceParser.Parse(line);

                foreach (var sentence in line.SentenceList)
                {
                    sentence.WordList = wordParser.Parse(sentence);
                }

            }
            


        }

    }
}
