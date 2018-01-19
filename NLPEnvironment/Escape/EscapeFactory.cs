using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Escape
{
    public static class EscapeFactory
    {
        private static List<EscapeCharacter> _escapeCharacters;
        private static object _locker = new object();

        public static List<EscapeCharacter> EscapeCharacters
        {
            get
            {
                lock (_locker)
                {
                    if (_escapeCharacters == null)
                    {
                        _escapeCharacters = new List<EscapeCharacter>();

                        _escapeCharacters.Add(new Dot());
                        _escapeCharacters.Add(new Comma());
                        _escapeCharacters.Add(new Brackets());
                        _escapeCharacters.Add(new Speak());
                        _escapeCharacters.Add(new Question());
                        _escapeCharacters.Add(new Warning());
                        _escapeCharacters.Add(new Colon());
                        _escapeCharacters.Add(new Dash());
                    }
                }

                return _escapeCharacters;
            }
        }
    }
}
