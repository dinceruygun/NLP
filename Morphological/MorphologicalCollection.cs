using NLPEnvironment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morphological
{
    public static class MorphologicalCollection
    {
        static WordCollection _wordList;
        static object _locker = new object();

        public static WordCollection WordList
        {
            get
            {
                if (_wordList == null)
                {
                    lock (_locker)
                    {
                        if (_wordList == null)
                        {
                            var reader = new MorphologicalBaseDataReader();
                            var data = reader.Read();
                        }
                    }
                }

                return _wordList;
            }
        }




    }
}
