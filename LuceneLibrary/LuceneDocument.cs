using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneLibrary
{
    internal class LuceneDocument:IDisposable
    {
        private Analyzer _Analyzer;
        private Directory _Directory;
        private IndexWriter _IndexWriter;
        private IndexSearcher _IndexSearcher;
        private IndexReader _IndexReader;
        private Document _Document;
        private QueryParser _QueryParser;
        private Query _Query;
        private string _IndexPath;



        public LuceneDocument(string indexPath)
        {
            _IndexPath = indexPath;

            init();
        }

        private void init()
        {
            _Analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            _Directory = FSDirectory.Open(_IndexPath);
        }



        public void AddToIndex(DataTable table)
        {
            using (_IndexWriter = new IndexWriter(_Directory, _Analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                foreach (DataRow row in table.Rows)
                {
                    _Document = new Document();

                    foreach (DataColumn col in table.Columns)
                    {
                        _Document.Add(new Field(col.ColumnName, row[col].ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    }

                    _IndexWriter.AddDocument(_Document);
                    _IndexWriter.Optimize();
                    _IndexWriter.Commit();
                }
            }
        }


        public DataTable GetAllDocuments()
        {
            if (!((_Directory as dynamic).Directory as System.IO.DirectoryInfo).Exists) return null;
            if (_Directory.ListAll().Length == 0) return null;


            _IndexReader = IndexReader.Open(_Directory, true);

            var docList = new List<Document>();
            int max = _IndexReader.MaxDoc;
            for (int iDoc = 0; iDoc < max; iDoc++)
            {
                var doc = _IndexReader.Document(iDoc);
                docList.Add(doc);
            }


            var result = DocumentToTable(docList);

            _IndexReader.Dispose();



            return result;
        }



        private DataTable DocumentToTable(List<Document> doc)
        {
            if (doc == null) return null;
            if (doc.Count == 0) return null;

            var result = new DataTable("result");

            foreach (var item in doc[0].GetFields())
                result.Columns.Add(item.Name);


            foreach (var item in doc)
            {
                var newRow = result.NewRow();

                foreach (DataColumn col in result.Columns)
                {
                    newRow[col] = item.GetValues(col.ColumnName)[0];
                }

                result.Rows.Add(newRow);
            }

            return result;
        }

        public void Dispose()
        {
            if (_IndexReader != null)
                _IndexReader.Dispose();
            

            _IndexReader = null;
            _Document = null;
        }
    }
}
