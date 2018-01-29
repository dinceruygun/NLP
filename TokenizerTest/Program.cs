using NlpAnalyseLibrary;
using NLPExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokenizer;

namespace TokenizerTest
{
    class Program
    {
        static void Main(string[] args)
        {




            var data = @"DEV DALGALAR OLUŞTU

                                                Istanbul'da sabah saatlerinden itibaren etkili olan lodos nedeniyle deniz seferlerinde aksamalar yasaniyor. Etkili olan lodos denizde dev dalgalar olusturdu. Istanbul Bogazi kiyilarinda lodos nedeniyle dalglarin sahile carpmasyla su seviyesi 3-4 metre yukseklige kadar cıktı.

                                                Olumsuz hava koşulları nedeniyle İDO ve BUDO da bazı seferler iptal edildi.";





            var tokenizer = new TokenizerManager(data);



            var result = tokenizer.Parse();



            var manager = new AnalyseManager();

            manager.Analyse(result);

        }
    }
}
