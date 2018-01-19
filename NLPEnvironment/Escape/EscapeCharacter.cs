using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public abstract class EscapeCharacter
    {
        char[] _escape;
        string _description;
        string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            internal set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            internal set
            {
                _description = value;
            }
        }

        public char[] Escape
        {
            get
            {
                return _escape;
            }

            internal set
            {
                _escape = value;
            }
        }


        public abstract EscapeType TypeControl(string text, int index);

    }
}
