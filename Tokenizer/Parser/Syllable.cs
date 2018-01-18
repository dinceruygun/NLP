using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer.Entities;

namespace Tokenizer.Parser
{
    public class Syllable
    {
        Entities.Word _word;

        public Entities.Word Word
        {
            get
            {
                return _word;
            }

            internal set
            {
                _word = value;
            }
        }


        public Syllable()
        {

        }



        public Syllable(Entities.Word word)
        {
            _word = word;
        }



        public Entities.SyllableCollection Parse(Entities.Word word)
        {
            _word = word;

            return Parse();
        }


        public Entities.SyllableCollection Parse()
        {
            if (Word == null) return null;


            var result = new Entities.SyllableCollection();
            var tempWord = new Entities.Syllable();



            Word.Text = Word.Text.ToLower().Trim();
            bool lastWasVowel = false;
            var vowels = new[] { 'a', 'e', 'i', 'ı', 'o', 'ö', 'u', 'ü' };

            tempWord.Text = "";


            string tempSyllable = "";
            List<int> wordPosition = new List<int>();
            for (int i = 0; i < Word.Text.Length; i++)
            {
                char tempKey = Word.Text[i];
                if (vowels.Contains(tempKey))
                {
                    tempSyllable = "";
                }
                else
                {
                    tempSyllable += tempKey;
                    if (tempSyllable.Length > 1)
                    {
                        wordPosition.Add(i - 1);
                    }
                }
            }
            wordPosition.Add(Word.Text.Length - 1);


            for (var i = 0; i < wordPosition.Count; i++)
            {
                string innerWord = Word.Text.Substring(
                    i == 0 ? 0 : wordPosition[i - 1] + 1,
                    i == 0 ? wordPosition[i] + 1 : wordPosition[i] - wordPosition[i - 1]);



                foreach (var c in innerWord)
                {
                    tempWord.Text += c;

                    if (vowels.Contains(c))
                    {
                        if (!lastWasVowel)
                        {
                            result.Add(tempWord);
                            tempWord = new Entities.Syllable();
                        }

                        lastWasVowel = true;
                    }
                    else
                    {
                        lastWasVowel = false;
                    }
                }

                if (tempWord?.Text?.Length > 0)
                {
                    if (result.Count == 0) { }
                    else { result.Last().Text += tempWord.Text; tempWord = new Entities.Syllable(); }
                }
            }





            return result;
        }
    }
}
