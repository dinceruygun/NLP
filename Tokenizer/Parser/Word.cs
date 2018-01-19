using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Parser
{
    public class Word
    {
        NLPEnvironment.Entities.Sentence _sentence;

        public NLPEnvironment.Entities.Sentence Sentence
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

        public Word(NLPEnvironment.Entities.Sentence sentence)
        {
            _sentence = sentence;
        }



        public NLPEnvironment.Entities.WordCollection Parse(NLPEnvironment.Entities.Sentence sentence)
        {
            _sentence = sentence;



            return Parse();
        }


        public NLPEnvironment.Entities.WordCollection Parse()
        {

            if (Sentence == null) return null;
            if (string.IsNullOrEmpty(Sentence.Text)) return null;



            var result = new NLPEnvironment.Entities.WordCollection();




            var tabs = Sentence.Text.Split(("\t").ToCharArray());

            foreach (var tab in tabs)
            {
                result.AddRange((tab.Split(' ')).Where(w => w != "" && w != " ").Select(w => new NLPEnvironment.Entities.Word(w.Trim().Replace("İ", "i").ToLower())).ToArray());
            }



            return result;
        }
    }
}
