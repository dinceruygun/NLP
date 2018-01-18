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

                                                İstanbul'da sabah saatlerinden itibaren etkili olan lodos nedeniyle deniz seferlerinde aksamalar yaşanıyor. Etkili olan lodos denizde dev dalgalar oluşturdu. İstanbul Boğazı kıyılarında lodos nedeniyle dalgaların sahile çarpmasıyla su seviyesi 3-4 metre yüksekliğe kadar çıktı.

                                                Olumsuz hava koşulları nedeniyle İDO ve BUDO da bazı seferler iptal edildi.";



            var t = data.Split(Environment.NewLine.ToCharArray()).Where(s => s != "").Select(s => s.Trim()).ToArray();


            var tokenizer = new TokenizerManager(data);



            tokenizer.Parse();

        }
    }
}
