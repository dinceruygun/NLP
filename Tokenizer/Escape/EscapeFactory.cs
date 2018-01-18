using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Escape
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
                    }
                }

                return _escapeCharacters;
            }
        }
    }
}
