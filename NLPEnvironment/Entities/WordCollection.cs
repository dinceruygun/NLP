using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    public class WordCollection : IList<Word>
    {

        private List<Word> WordList;


        public WordCollection()
        {
            WordList = new List<Word>();
        }


        public Word this[int index]
        {
            get
            {
                return WordList[index];
            }

            set
            {
                WordList[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return WordList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Word item)
        {
            WordList.Add(item);
        }

        public void Clear()
        {
            WordList.Clear();
        }

        public void AddRange(Word[] items)
        {
            WordList.AddRange(items);
        }

        public bool Contains(Word item)
        {
            return WordList.Contains(item);
        }

        public void CopyTo(Word[] array, int arrayIndex)
        {
            WordList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Word> GetEnumerator()
        {
            return WordList.GetEnumerator();
        }

        public int IndexOf(Word item)
        {
            return WordList.IndexOf(item);
        }

        public void Insert(int index, Word item)
        {
            WordList.Insert(index, item);
        }

        public bool Remove(Word item)
        {
            return WordList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            WordList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return WordList.GetEnumerator();
        }
    }
}
