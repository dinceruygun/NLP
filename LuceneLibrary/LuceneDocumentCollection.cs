using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneLibrary
{
    internal class LuceneDocumentCollection : IDictionary<string, LuceneDocument>
    {

        Dictionary<string, LuceneDocument> LuceneDocumentList;


        public LuceneDocumentCollection()
        {
            LuceneDocumentList = new Dictionary<string, LuceneDocument>();
        }


        public LuceneDocument this[string key]
        {
            get
            {
                return LuceneDocumentList[key];
            }

            set
            {
                LuceneDocumentList[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return LuceneDocumentList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                return LuceneDocumentList.Keys;
            }
        }

        public ICollection<LuceneDocument> Values
        {
            get
            {
                return LuceneDocumentList.Values;
            }
        }

        public void Add(KeyValuePair<string, LuceneDocument> item)
        {
            LuceneDocumentList.Add(item.Key, item.Value);
        }

        public void Add(string key, LuceneDocument value)
        {
            LuceneDocumentList.Add(key, value);
        }

        public void Clear()
        {
            LuceneDocumentList.Clear();
        }

        public bool Contains(KeyValuePair<string, LuceneDocument> item)
        {
            return LuceneDocumentList.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return LuceneDocumentList.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, LuceneDocument>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, LuceneDocument>> GetEnumerator()
        {
            return LuceneDocumentList.GetEnumerator();
        }

        public bool Remove(KeyValuePair<string, LuceneDocument> item)
        {
            return LuceneDocumentList.Remove(item.Key);
        }

        public bool Remove(string key)
        {
            return LuceneDocumentList.Remove(key);
        }

        public bool TryGetValue(string key, out LuceneDocument value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return LuceneDocumentList.GetEnumerator();
        }
    }
}
