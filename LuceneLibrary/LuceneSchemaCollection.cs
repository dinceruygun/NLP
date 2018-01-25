using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneLibrary
{
    internal class LuceneSchemaCollection : IList<LuceneSchema>
    {
        List<LuceneSchema> LuceneSchemaList;

        public LuceneSchemaCollection()
        {
            LuceneSchemaList = new List<LuceneSchema>();
        }


        public LuceneSchema this[int index]
        {
            get
            {
                return LuceneSchemaList[index];
            }

            set
            {
                LuceneSchemaList[index] = value;
            }
        }

        public LuceneSchema this[string name]
        {
            get
            {
                return LuceneSchemaList.Find(c => c.Name == name.Trim());
            }
        }

        public int Count
        {
            get
            {
                return LuceneSchemaList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(LuceneSchema item)
        {
            if (LuceneSchemaList.Find(c => c.Name == item.Name.Trim()) != null) throw new DuplicateWaitObjectException();

            LuceneSchemaList.Add(item);
        }

        public void Clear()
        {
            LuceneSchemaList.Clear();
        }

        public bool Contains(LuceneSchema item)
        {
            return LuceneSchemaList.Contains(item);
        }

        public void CopyTo(LuceneSchema[] array, int arrayIndex)
        {
            LuceneSchemaList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<LuceneSchema> GetEnumerator()
        {
            return LuceneSchemaList.GetEnumerator();
        }

        public int IndexOf(LuceneSchema item)
        {
            return LuceneSchemaList.IndexOf(item);
        }

        public void Insert(int index, LuceneSchema item)
        {
            LuceneSchemaList.Insert(index, item);
        }

        public bool Remove(LuceneSchema item)
        {
            return LuceneSchemaList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            LuceneSchemaList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return LuceneSchemaList.GetEnumerator();
        }
    }
}
