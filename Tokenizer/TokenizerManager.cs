using Morphological;
using NLPExtention;
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





        public NLPEnvironment.Entities.LineCollection Parse(string Text)
        {
            this._baseText = Text;
            return this.Parse();
        }

        public NLPEnvironment.Entities.LineCollection Parse()
        {
            if (string.IsNullOrEmpty(BaseText)) return null;

            var lineParser = new Parser.Line();
            var sentenceParser = new Parser.Sentence();
            var wordParser = new Parser.Word();
            var syllableParser = new Parser.Syllable();
            var morphManager = new MorphologicalManager();



            var lines = lineParser.Parse(BaseText);

            foreach (var line in lines)
            {
                line.SentenceList = sentenceParser.Parse(line);

                foreach (var sentence in line.SentenceList)
                {
                    sentence.WordList = wordParser.Parse(sentence);

                    foreach (var word in sentence.WordList)
                    {
                        word.Text = word.Text.ToTurkish();
                        var morphList = morphManager.SimilarWords(word);

                        if (morphList != null)
                        {
                            word.SimilarWordList = morphList.WordList;

                            if (morphList.SelectWord != null)
                            {
                                word.SpellWord = morphList.SelectWord;
                            }
                        }



                        word.Syllable = syllableParser.Parse(word);
                    }

                }

            }



            return lines;

        }

    }
}
