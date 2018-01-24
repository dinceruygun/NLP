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


        static Dictionary<int, WordCollection> _wordIndexList;


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
                            _wordList = reader.Read();
                        }
                    }
                }

                return _wordList;
            }
        }

        public static Dictionary<int, WordCollection> WordIndexList
        {
            get
            {
                if (_wordIndexList == null)
                {
                    lock (_locker)
                    {
                        if (_wordIndexList == null)
                        {
                            _wordIndexList = new Dictionary<int, WordCollection>();
                            var reader = new MorphologicalBaseDataReader();
                            var _length = 0;

                            foreach (var word in reader.Read().Where(w=>w.Length > 3).OrderBy(w => w.Length).ToList())
                            {
                                if (_length == 0) _length = word.Length;
                                else if (_length < word.Length) _length = word.Length + 2;



                                if (_wordIndexList.ContainsKey(_length))
                                {
                                    _wordIndexList[_length].Add(word);
                                }
                                else
                                {
                                    var collection = new WordCollection();
                                    collection.Add(word);

                                    _wordIndexList.Add(_length, collection);
                                }

                                
                            }
                        }
                    }
                }

                return _wordIndexList;
            }
        }
    }
}
