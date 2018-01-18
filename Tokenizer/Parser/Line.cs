using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Parser
{
    public class Line
    {
        private string _baseText;

        public string BaseText
        {
            get
            {
                return _baseText;
            }
        }


        public Line()
        {

        }


        public Line(string Text)
        {
            this._baseText = Text;
        }


        public Entities.LineCollection Parse()
        {
            if (string.IsNullOrEmpty(BaseText)) return null;


            var result = new Entities.LineCollection();

            result.AddRange(BaseText.Split(Environment.NewLine.ToCharArray()).Where(s => s != "").Select(s => new Entities.Line(s.Trim())).ToArray());

            return result;
        }

        public void Parse(string Text)
        {
            this._baseText = Text;
            this.Parse();
        }
    }
}
