using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Parser
{
    public class Word
    {
        Entities.Sentence _sentence;

        public Entities.Sentence Sentence
        {
            get
            {
                return _sentence;
            }

            internal set
            {
                _sentence = value;
            }
        }


        public Word()
        {

        }

        public Word(Entities.Sentence sentence)
        {
            _sentence = sentence;
        }



        public Entities.WordCollection Parse(Entities.Sentence sentence)
        {
            _sentence = sentence;



            return Parse();
        }


        public Entities.WordCollection Parse()
        {

            if (Sentence == null) return null;
            if (string.IsNullOrEmpty(Sentence.Text)) return null;



            var result = new Entities.WordCollection();




            var tabs = Sentence.Text.Split(("\t").ToCharArray());

            foreach (var tab in tabs)
            {
                result.AddRange((tab.Split(' ')).Where(w => w != "" && w != " ").Select(w => new Entities.Word(w.Trim().Replace("İ", "i").ToLower())).ToArray());
            }



            return result;
        }
    }
}
