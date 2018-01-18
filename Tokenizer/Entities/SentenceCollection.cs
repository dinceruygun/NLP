using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Entities
{
    public class SentenceCollection : IList<Sentence>
    {
        private List<Sentence> SentenceList;


        public SentenceCollection()
        {
            SentenceList = new List<Sentence>();
        }

        public Sentence this[int index]
        {
            get
            {
                return SentenceList[index];
            }

            set
            {
                SentenceList[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return SentenceList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Sentence item)
        {
            SentenceList.Add(item);
        }

        public void Clear()
        {
            SentenceList.Clear();
        }

        public bool Contains(Sentence item)
        {
            return SentenceList.Contains(item);
        }

        public void CopyTo(Sentence[] array, int arrayIndex)
        {
            SentenceList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Sentence> GetEnumerator()
        {
            return SentenceList.GetEnumerator();
        }

        public int IndexOf(Sentence item)
        {
            return SentenceList.IndexOf(item);
        }

        public void Insert(int index, Sentence item)
        {
            SentenceList.Insert(index, item);
        }

        public bool Remove(Sentence item)
        {
            return SentenceList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            SentenceList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SentenceList.GetEnumerator();
        }
    }
}
