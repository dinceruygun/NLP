using NLPEnvironment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    public class SyllableEscape: ISyllableType
    {
        NLPEnvironment.Escape.EscapeItem _escapeItem;

        public NLPEnvironment.Escape.EscapeItem EscapeItem
        {
            get
            {
                return _escapeItem;
            }

            set
            {
                _escapeItem = value;
            }
        }
    }
}
