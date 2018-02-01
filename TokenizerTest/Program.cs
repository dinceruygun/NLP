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




            var data = @"İstanbul Üsküdar'da kontrolden çıkan halk otobüsü, durakta bekleyenlere çarptı, 2'si kadın 3 kişi hayatını kaybetti. 

Alınan bilgiye göre Dr. Eyüp Aksoy Caddesi (Karacaahmet Mezarlığı yanındaki yol) üzerinde seyir halindeki Ataşehir-Kadıköy seferini yapan özel halk otobüsü, durağa yaklaştığı sırada İETT otobüsüyle çarpıştıktan sonra kontrolden çıkıp, otobüs durağında bekleyenlere çarptı.

Durakta bekleyen yolculardan Ayşegül Erdoğan, Mustafa Erdoğan ve Perihan Çelik yaşamını yitirdi.

Yaralılar Haydarpaşa Numune Eğitim ve Araştırma Hastanesi ve çevredeki hastanelere kaldırıldı. 

Kaza nedeniyle Dr. Eyüp Aksoy Caddesi, Üsküdar istikametine kapatıldı. 

Sürücüler ifadeleri alınmak üzere karakola götürülürken, kazayla ilgili soruşturmanın sürdürüldüğü öğrenildi.

SEFERE DÜN BAŞLAMIŞ

Bu arada İstanbul Özel Halk Otobüsü Şirketleri, kazaya neden olan otobüsün dün itibariyle hizmete başlamış yeni nesil bir araç olduğunu bildirdi.

Açıklamada ""Elim kaza nedeniyle derin üzüntülerimizi ifade ederken vefat eden vatandaşlarımıza yüce Allah’tan rahmet ve mağfiret, ailesine ve akrabalarına baş sağlığı, yaralı olan vatandaşlarımıza acil şifalar temenni ediyoruz."" ifadelerine de yer verildi.";





            var tokenizer = new TokenizerManager(data);



            var result = tokenizer.Parse();



            var manager = new AnalyseManager();

            manager.Analyse(result);

        }
    }
}
