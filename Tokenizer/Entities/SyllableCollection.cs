using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Entities
{
    public class SyllableCollection : IList<Syllable>
    {
        private List<Syllable> SyllableList;


        public SyllableCollection()
        {
            SyllableList = new List<Syllable>();
        }


        public Syllable this[int index]
        {
            get
            {
                return SyllableList[index];
            }

            set
            {
                SyllableList[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return SyllableList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Syllable item)
        {
            SyllableList.Add(item);
        }

        public void Clear()
        {
            SyllableList.Clear();
        }

        public bool Contains(Syllable item)
        {
            return SyllableList.Contains(item);
        }

        public void CopyTo(Syllable[] array, int arrayIndex)
        {
            SyllableList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Syllable> GetEnumerator()
        {
            return SyllableList.GetEnumerator();
        }

        public int IndexOf(Syllable item)
        {
            return SyllableList.IndexOf(item);
        }

        public void Insert(int index, Syllable item)
        {
            SyllableList.Insert(index, item);
        }

        public bool Remove(Syllable item)
        {
            return SyllableList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            SyllableList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SyllableList.GetEnumerator();
        }
    }
}
