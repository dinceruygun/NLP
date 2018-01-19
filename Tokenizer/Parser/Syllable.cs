using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tokenizer.Parser
{
    public class Syllable
    {
        NLPEnvironment.Entities.Word _word;

        public NLPEnvironment.Entities.Word Word
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



        public Syllable(NLPEnvironment.Entities.Word word)
        {
            _word = word;
        }



        public NLPEnvironment.Entities.SyllableCollection Parse(NLPEnvironment.Entities.Word word)
        {
            _word = word;

            return Parse();
        }




        public NLPEnvironment.Entities.SyllableCollection Parse()
        {
            if (Word == null) return null;


            var result = new NLPEnvironment.Entities.SyllableCollection();


            var escapeConstol = new NLPEnvironment.Escape.EscapeControl();
            var escapeList = escapeConstol.CheckEscape(Word.Text);


            if (escapeList.Count == 0) escapeList.Add(0, new NLPEnvironment.Escape.EscapeItem() { Index = Word.Text.Length, EscapeType = NLPEnvironment.Escape.EscapeType.NONE });
            else escapeList.Add(-1, new NLPEnvironment.Escape.EscapeItem() { Index = Word.Text.Length, EscapeType = NLPEnvironment.Escape.EscapeType.NONE });


            var processIndex = 0;
            foreach (var escape in escapeList)
            {
                var val = Word.Text.Substring(processIndex, escape.Value.Index - processIndex);
                var s_val = SyllableParse(val);

                foreach (var item in s_val)
                {
                    item.SyllableType = new NLPEnvironment.Entities.SyllableNormal() { Text = "" };
                    result.Add(item);
                }


                if (escape.Value.EscapeCharacter != null)
                {
                    result.Add(new NLPEnvironment.Entities.Syllable()
                    {
                        SyllableType = new NLPEnvironment.Entities.SyllableEscape() { EscapeItem = escape.Value },
                        Text = Word.Text.Substring(escape.Value.Index, 1)
                    });
                }


                processIndex = escape.Value.Index + 1;
            }



            return result;


        }





        private NLPEnvironment.Entities.SyllableCollection SyllableParse(string Text)
        {
            var result = new NLPEnvironment.Entities.SyllableCollection();
            var tempWord = new NLPEnvironment.Entities.Syllable();



            Text = Text.ToLower().Trim();
            bool lastWasVowel = false;
            var vowels = new[] { 'a', 'e', 'i', 'ı', 'o', 'ö', 'u', 'ü' };

            tempWord.Text = "";


            string tempSyllable = "";
            List<int> wordPosition = new List<int>();
            for (int i = 0; i < Text.Length; i++)
            {
                char tempKey = Text[i];
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
            wordPosition.Add(Text.Length - 1);


            for (var i = 0; i < wordPosition.Count; i++)
            {
                string innerWord = Text.Substring(
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
                            tempWord = new NLPEnvironment.Entities.Syllable();
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
                    else { result.Last().Text += tempWord.Text; tempWord = new NLPEnvironment.Entities.Syllable(); }
                }
            }





            return result;
        }


    }
}
