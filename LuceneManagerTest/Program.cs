using LuceneLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new LuceneManager();
            if (!manager.ExistSchema("nlp")) manager.AddSchema("nlp");

            var table = new DataTable("test");
            table.Columns.Add("adi");
            table.Columns.Add("soyadi");


            var r1 = table.NewRow();
            r1["adi"] = "dinçer";
            r1["soyadi"] = "uygun";

            var r2 = table.NewRow();
            r2["adi"] = "lokman";
            r2["soyadi"] = "çetin";

            var r3 = table.NewRow();
            r3["adi"] = "serkan";
            r3["soyadi"] = "akın";




            table.Rows.Add(r1);
            table.Rows.Add(r2);
            table.Rows.Add(r3);



            manager.Index("", table);

        }
    }
}
