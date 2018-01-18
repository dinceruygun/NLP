using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Entities
{
    public abstract class TokenizerEntity
    {

        int _id;

        public int Id
        {
            get
            {
                return _id;
            }

            internal set
            {
                _id = value;
            }
        }
    }
}
