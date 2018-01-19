using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Parser
{
    public class Sentence
    {
        NLPEnvironment.Entities.Line _line;

        public NLPEnvironment.Entities.Line Line
        {
            get
            {
                return _line;
            }

            internal set
            {
                _line = value;
            }
        }


        public Sentence()
        {

        }

        public Sentence(NLPEnvironment.Entities.Line line)
        {
            _line = line;
        }


        public NLPEnvironment.Entities.SentenceCollection Parse(NLPEnvironment.Entities.Line line)
        {
            _line = line;

            return Parse();
        }


        public NLPEnvironment.Entities.SentenceCollection Parse()
        {
            if (Line == null) return null;


            var result = new NLPEnvironment.Entities.SentenceCollection();
            var escapeControl = new Escape.EscapeControl();


            var escapeList = escapeControl.CheckEscape(Line.Text);


            if (escapeList.Count == 0)
            {
                result.Add(new NLPEnvironment.Entities.Sentence(Line, Line.Text));
                return result;
            }




            var startIndex = 0;
            foreach (var e in escapeList.Where(e => e.Value.EscapeType == Escape.EscapeType.END))
            {
                var text = Line.Text.Substring(startIndex, (e.Value.Index + 1) - startIndex).Trim();

                result.Add(new NLPEnvironment.Entities.Sentence(Line, text));


                startIndex = e.Value.Index + 1;
            }




            return result;
        }
    }
}
