using LuceneLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LuceneAddressIndex
{
    class Program
    {
        static DataTable TableUlke;
        static DataTable TableSehirler;
        static DataTable TableIlceler;
        static DataTable TableSemtMahalle;


        static void Main(string[] args)
        {
            LoadUlkeler();
            LoadSehirler();
            LoadIlceler();
            LoadSemtMahalle();





            var manager = new LuceneManager();
            if (!manager.ExistSchema("address")) manager.AddSchema("address");

            Console.WriteLine("Ülkeler indeksleniyor");
            manager.Index("address", TableUlke);


            Console.WriteLine("Şehirler indeksleniyor");
            manager.Index("address", TableSehirler);


            Console.WriteLine("İlceler indeksleniyor");
            manager.Index("address", TableIlceler);


            Console.WriteLine("Semt mahalle indeksleniyor");
            manager.Index("address", TableSemtMahalle);
        }





        static void LoadSemtMahalle()
        {
            LoadTableSemtMahalle();

            var dataSemtMahalle = ReadData("samtmahalle.txt");
            foreach (var item in dataSemtMahalle.Split(Environment.NewLine.ToCharArray()))
            {
                var splitData = item.Split(',');

                var newRow = TableSemtMahalle.NewRow();

                newRow["semtmahalleid"] = splitData[0];
                newRow["semtadi"] = splitData[1];
                newRow["mahalleadi"] = splitData[2];
                newRow["postakodu"] = splitData[3];
                newRow["ilceid"] = splitData[4];


                TableSemtMahalle.Rows.Add(newRow);
            }
        }

        static void LoadIlceler()
        {
            LoadTableIlceler();

            var dataIlce = ReadData("ilceler.txt");
            foreach (var item in dataIlce.Split(Environment.NewLine.ToCharArray()))
            {
                var splitData = item.Split(',');

                var newRow = TableIlceler.NewRow();

                newRow["ilceid"] = splitData[0];
                newRow["sehirid"] = splitData[1];
                newRow["ilceadi"] = splitData[2];
                //newRow["sehiradi"] = splitData[3];


                TableIlceler.Rows.Add(newRow);
            }
        }

        static void LoadSehirler()
        {
            LoadTableSehirler();

            var dataSehir = ReadData("sehirler.txt");
            foreach (var item in dataSehir.Split(Environment.NewLine.ToCharArray()))
            {
                var splitData = item.Split(',');

                var newRow = TableSehirler.NewRow();

                newRow["sehirid"] = splitData[0];
                newRow["sehiradi"] = splitData[1];
                newRow["plakano"] = splitData[2];
                newRow["telefonkodu"] = splitData[3];
                newRow["ulkeid"] = "212";


                TableSehirler.Rows.Add(newRow);
            }
        }

        static void LoadUlkeler()
        {
            LoadTableUlke();

            var dataUlke = ReadData("ulkeler.txt");
            foreach (var item in dataUlke.Split(Environment.NewLine.ToCharArray()))
            {
                var splitData = item.Split(',');

                var newRow = TableUlke.NewRow();

                newRow["ulkeid"] = splitData[0];
                newRow["ikilikod"] = splitData[1];
                newRow["uclukod"] = splitData[2];
                newRow["ulkeadi"] = splitData[3];
                newRow["telkodu"] = splitData[4];


                TableUlke.Rows.Add(newRow);
            }
        }

        static void LoadTableUlke()
        {
            TableUlke = new DataTable("ulkeler");

            TableUlke.Columns.Add("ulkeid");
            TableUlke.Columns.Add("ikilikod");
            TableUlke.Columns.Add("uclukod");
            TableUlke.Columns.Add("ulkeadi");
            TableUlke.Columns.Add("telkodu");
        }

        static void LoadTableSehirler()
        {
            TableSehirler = new DataTable("sehirler");

            TableSehirler.Columns.Add("sehirid");
            TableSehirler.Columns.Add("sehiradi");
            TableSehirler.Columns.Add("plakano");
            TableSehirler.Columns.Add("telefonkodu");
            TableSehirler.Columns.Add("ulkeid");
        }

        static void LoadTableIlceler()
        {
            TableIlceler = new DataTable("ilceler");

            TableIlceler.Columns.Add("ilceid");
            TableIlceler.Columns.Add("sehirid");
            TableIlceler.Columns.Add("ilceadi");
            //TableIlceler.Columns.Add("sehiradi");
        }

        static void LoadTableSemtMahalle()
        {
            TableSemtMahalle = new DataTable("semtmahalle");

            TableSemtMahalle.Columns.Add("semtmahalleid");
            TableSemtMahalle.Columns.Add("semtadi");
            TableSemtMahalle.Columns.Add("mahalleadi");
            TableSemtMahalle.Columns.Add("postakodu");
            TableSemtMahalle.Columns.Add("ilceid");
        }

        static string ReadData(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"LuceneAddressIndex.container.{filename}";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
