using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenizer.Entities
{
    public class LineCollection : IList<Line>
    {

        protected List<Line> _lineCollection;


        public LineCollection()
        {
            _lineCollection = new List<Line>();
        }


        public Line this[int index]
        {
            get
            {
                return _lineCollection[index];
            }

            set
            {
                _lineCollection[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _lineCollection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }


        public void AddRange(Line[] items)
        {
            _lineCollection.AddRange(items);

            SetId();
        }


        public void Add(Line item)
        {
            _lineCollection.Add(item);

            SetId();
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }

        public bool Contains(Line item)
        {
            return _lineCollection.Contains(item);
        }

        public void CopyTo(Line[] array, int arrayIndex)
        {
            _lineCollection.CopyTo(array, arrayIndex);

            SetId();
        }

        public IEnumerator<Line> GetEnumerator()
        {
            return _lineCollection.GetEnumerator();
        }

        public int IndexOf(Line item)
        {
            return _lineCollection.IndexOf(item);
        }

        public void Insert(int index, Line item)
        {
            _lineCollection.Insert(index, item);

            SetId();
        }

        public bool Remove(Line item)
        {
            var result = _lineCollection.Remove(item);

            SetId();

            return result;
        }

        public void RemoveAt(int index)
        {
            _lineCollection.RemoveAt(index);

            SetId();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _lineCollection.GetEnumerator();
        }


        private void SetId()
        {
            for (int i = 0; i < _lineCollection.Count; i++)
                _lineCollection[i].Id = i;
        }
    }
}
