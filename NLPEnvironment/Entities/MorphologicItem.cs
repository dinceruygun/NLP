using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPEnvironment.Entities
{
    [System.Diagnostics.DebuggerDisplay("{ToString()}")]
    public class MorphologicItem
    {
        private string _morphologicText;
        MorphologicType _morphologic;


        public MorphologicItem(string morpholohic)
        {
            this._morphologicText = morpholohic;

            this._morphologic = MorphologicTypeFactory.MorphologicTypeList.Find(m => m.Name == morpholohic);
        }


        public MorphologicItem()
        {

        }

        public string MorphologicText
        {
            get
            {
                return _morphologicText;
            }
        }

        public MorphologicType Morphologic
        {
            get
            {
                return _morphologic;
            }
        }


        public override string ToString()
        {
            return Morphologic == null ? "" : $"{Morphologic.Name} - {Morphologic.Description}";
        }
    }




    public static class MorphologicTypeFactory
    {
        private static List<MorphologicType> _morphologicTypeList;
        private static object _locker = new object();

        public static List<MorphologicType> MorphologicTypeList
        {
            get
            {
                if (_morphologicTypeList == null)
                {
                    lock (_locker)
                    {
                        if (_morphologicTypeList == null)
                        {
                            _morphologicTypeList = new List<MorphologicType>();

                            _morphologicTypeList.Add(new MorphologicType("Noun", "İsim", " kedi, kitap (cat, book)"));
                            _morphologicTypeList.Add(new MorphologicType("A3sg", "Üçüncü Tekil Şahıs", " "));
                            _morphologicTypeList.Add(new MorphologicType("P3sg", "Üçüncü Kişi Tekil Sahip Olma", " "));
                            _morphologicTypeList.Add(new MorphologicType("Nom", "Bükülme olmadığında durum ekidir", " "));
                            _morphologicTypeList.Add(new MorphologicType("Abl", "Ablatif -den hali", " "));
                            _morphologicTypeList.Add(new MorphologicType("Pnon", "Elde Edilme Yok", " "));
                            _morphologicTypeList.Add(new MorphologicType("Adj", "Sıfat", " sıcak soğuk (hot, cold)"));
                            _morphologicTypeList.Add(new MorphologicType("With", "İle, birlikte, beraber", " limon-lu, yün-lü (with lemon, with wool) Converts word to an Adjective. I think we can assume this can only be added to nouns. ISIM#_BULUNMA#_LI"));
                            _morphologicTypeList.Add(new MorphologicType("A3pl", "Üçüncü şahıs çoğul", " "));
                            _morphologicTypeList.Add(new MorphologicType("Apos", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("Loc", "Yer belirten", " araba-da, kalem-de (in the car, on the pencil). It is produced in #[ndA#] form if follows P3sg. kedi-si-nde."));
                            _morphologicTypeList.Add(new MorphologicType("Dat", "Datif. Yönelme durumu", " araba-ya, kalem-e (to car, to pencil). It is produced in #[nA#] form if follows P3sg. kedi-si-ne."));
                            _morphologicTypeList.Add(new MorphologicType("Gen", "in hali", " kedi-nin, kitab-ın (cat’s, book’s). Generates ambiguity with P2sg. ‘kedinin’ has two parses. kedi+P2sg+Gen and kedi+Gen. "));
                            _morphologicTypeList.Add(new MorphologicType("Ins", "Enstrümental (Hangisi ile)", " domates-le, kova-yla"));
                            _morphologicTypeList.Add(new MorphologicType("Verb", "Fiil, eylem", " gel, git (come, go)"));
                            _morphologicTypeList.Add(new MorphologicType("Pos", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("PresPart", "Mevcut partikül", " otur-an-dan (from the one sitting)"));
                            _morphologicTypeList.Add(new MorphologicType("Inf2", "Mastar", " otur-ma-ya (of sitting, to sit) Converts to a noun. Ambigious with Negative suffix."));
                            _morphologicTypeList.Add(new MorphologicType("P2sg", "İkinci şahıs tekil mülkiyet hakkı", " kedi-n, göz-ün (your cat, your eye). su-yun"));
                            _morphologicTypeList.Add(new MorphologicType("Inf3", "Mastar", " otur-uş-unuz (your sitting) Converts to a noun"));
                            _morphologicTypeList.Add(new MorphologicType("Acc", "İsmin -i hali", " kedi-yi, kitab-ı, Generates ambiguity with P3sg. If comes after "));
                            _morphologicTypeList.Add(new MorphologicType("Rel", "", " masa-da-ki kalem, dün-kü toplantı (the pencil on the table, yesterday’s meeting). Converts to an Adjective. However, This suffix is splitted to two parts in Zemberek-2. One is used after Loc suffix (masa-da-ki , BULUNMA), another is appended to nouns representing date-time (dün-kü, yarın-ki, BELIRTME). One idea may be to generate a separate suffıx for “dAki“. "));
                            _morphologicTypeList.Add(new MorphologicType("Pres", "Mevcut", " "));
                            _morphologicTypeList.Add(new MorphologicType("Cop", "Genelleme", " "));
                            _morphologicTypeList.Add(new MorphologicType("P1pl", "Birinci Şahısta Çoklu İmtiyaz", " kedi-miz, göz-ümüz (our cat, our eye). Note that you can write kedi-ler-imiz (our cats). "));
                            _morphologicTypeList.Add(new MorphologicType("P1sg", "Birinci Şahıs Tekil Konuşma", " kedi-m, göz-üm (my cat, my eye). su-yum"));
                            _morphologicTypeList.Add(new MorphologicType("Past", "Geçmiş", " "));
                            _morphologicTypeList.Add(new MorphologicType("Narr", "Mişli geçmiş zaman", " "));
                            _morphologicTypeList.Add(new MorphologicType("A1sg", "Birinci şahıs tekil", " gid-eceğ-im, hasta-yım, yap-tı-m (I will go, I am sick, I did)."));
                            _morphologicTypeList.Add(new MorphologicType("Cond", "Şartlı", " yap-sa-k, yap-acak-mış-sa. In zemberek two separate suffixes are used for these. FIIL#_SART#_SE and IMEK#_SART#_SE. Second one can also be attached to a noun or adjective. Oflazer however, uses the same suffix name for both. And if added to a noun, it creates a zero morpheme verb derivation. Example: öyleyse:öyle+Adj^DB+Verb+Zero+Cond+A3sg"));
                            _morphologicTypeList.Add(new MorphologicType("Adv", "Zarf", " dün, ileri (yesterday, forward)"));
                            _morphologicTypeList.Add(new MorphologicType("While", "Süre", " "));
                            _morphologicTypeList.Add(new MorphologicType("Pass", "Pasif edilgen", " yap-ıl-acak (to be done, will be done)if verb ends with letter ‘l’ or ends with a vowel, +In rule applies: gel-in-en, ara-n-an.Oflazer also parses #[nIl#] as Passive. As in ara-nıl-mak.Zemberek2 gets it wrong by having an extra hacky suffix called FIIL#_EDILGENSESLI#_N. The passive suffix is FIIL#_EDILGEN#_IL."));
                            _morphologicTypeList.Add(new MorphologicType("AfterDoingSo", "Ardından yaptıktan sonra", " "));
                            _morphologicTypeList.Add(new MorphologicType("Aor", "Şimdiki zaman", " "));
                            _morphologicTypeList.Add(new MorphologicType("Prog1", "İlerici", " "));
                            _morphologicTypeList.Add(new MorphologicType("Opt", "İstek belirten", " göster-e-yim, göster-e. FIIL#_ISTEK#_E"));
                            _morphologicTypeList.Add(new MorphologicType("Fut", "Gelecek", " gel-ecek, gid-eceğ-i. This suffıx also generates ambiguity with the derivational Future Participle FutPart (+yAcAk) suffix. (Ahmet yazacak - Yazacağı defter nerede?) "));
                            _morphologicTypeList.Add(new MorphologicType("Neces", "Gereklilik / Yükümlülük", " "));
                            _morphologicTypeList.Add(new MorphologicType("Neg", "Olumsuz", " "));
                            _morphologicTypeList.Add(new MorphologicType("Imp", "Zorunlu", " "));
                            _morphologicTypeList.Add(new MorphologicType("A2pl", "İkinci şahıs çoğul", " gid-ecek-siniz, hasta-sınız, gel-di-niz ( you will come, you are sick, you came)"));
                            _morphologicTypeList.Add(new MorphologicType("When", "Ne zaman", " "));
                            _morphologicTypeList.Add(new MorphologicType("A1pl", "Birinci şahıs çoğul", " gid-eceğ-iz, hasta-yız, yaptı-k (we will go, we are sick, we did)"));
                            _morphologicTypeList.Add(new MorphologicType("Become", "Olmak", " olgun-laş-tı (it became ripe). Converts to a verb. This suffix may be used for some nouns too (taş-laş-mak,  to become stone). Therefore this either can be generalized for nouns too, or the noun forms can be added to Lexicon as verbs."));
                            _morphologicTypeList.Add(new MorphologicType("Without", "Olmadan", " "));
                            _morphologicTypeList.Add(new MorphologicType("Hastily", "Alalacele", " "));
                            _morphologicTypeList.Add(new MorphologicType("PastPart", "Geçmiş partikül", " yap-tığ-ı (the thing he did) Oflazer suggests this converts to a noun or an adjective."));
                            _morphologicTypeList.Add(new MorphologicType("Desr", "Karşılıklı anlayış", " "));
                            _morphologicTypeList.Add(new MorphologicType("A2sg", "İkinci şahıs tekil", " gid-ecek-sin, hasta-sın, yap-tı-n (you will go, you are sick, you did)"));
                            _morphologicTypeList.Add(new MorphologicType("Able", "Yapabilmek", " "));
                            _morphologicTypeList.Add(new MorphologicType("FutPart", "Gelecekteki partikül", " otur-acağ-ı sandalye (the chair he will sit) Oflazer suggests this converts to a noun or an adjective."));
                            _morphologicTypeList.Add(new MorphologicType("Agt", "Agentive", " Yor-ucu-ydu (it was tiring) Converts to a noun. It has the similar usage with Noun ‘Agt’ suffix. "));
                            _morphologicTypeList.Add(new MorphologicType("P3pl", "Üçüncü Kişi Çoklu Sahip Olduğu Haklar", " kedi-leri, burun-ları (their cats - his cats, their noses - his noses). Here you cannot write (kedi-ler-leri). "));
                            _morphologicTypeList.Add(new MorphologicType("ByDoingSo", "Böylece yaparak", " "));
                            _morphologicTypeList.Add(new MorphologicType("Prog2", "Aşamalı (Devlet)", " oku-makta . This suffix creates ambiguity with derivational mak+ta (Şu an oku-makta & onu oku-mak-ta ısrar etti.). In zemberek there is no such suffix. "));
                            _morphologicTypeList.Add(new MorphologicType("Caus", "Ettirgen", " sat-tır-mak (to get it sold). if verb ends with a vowel, suffix form is ‘t’; ara-t-mak. if verb has more than one syllable and ends with  ‘r’ or ‘l’, suffix also forms as ‘t’: düşür-t-mek or yanıl-t-mak. There is another variation, for some verbs suffix may form as ‘It’ such as: kok-ut-mak. "));
                            _morphologicTypeList.Add(new MorphologicType("Asıf", "Sanki", " "));
                            _morphologicTypeList.Add(new MorphologicType("Inf1", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("NarrNess", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("AsLongAs", "Olduğu sürece", " "));
                            _morphologicTypeList.Add(new MorphologicType("P2pl", "İkinci Kişi Çoklu Sahip Oldu", " kedi-niz, göz-ünüz (your cat, your eye). Note that you can write kedi-ler-iniz (your cats)"));
                            _morphologicTypeList.Add(new MorphologicType("Prop", "Özel ad", " Ankara, Google. Can only be a  Noun."));
                            _morphologicTypeList.Add(new MorphologicType("Acquire", "Kazanmak", " endişe-len-mek (to get worry). This convert a noun to a passive"));
                            _morphologicTypeList.Add(new MorphologicType("SinceDoingSo", "Yaptıklarından beri", " "));
                            _morphologicTypeList.Add(new MorphologicType("Equ", "Eşitlik", " "));
                            _morphologicTypeList.Add(new MorphologicType("Dim", "Azaltıcı (Sevecenlik ve Sevgi)", " kedi-cik, küp-çük, masa-cığ-a (little cat, little cube, to little table). A new noun forms with this suffix. Oflazer also accepts an informal suffix as Dimunative too, such as kedi-cim. In zemberek 2, some deformations like küçücük, minicik and ufacık are also handled. ISIM#_KUCULTME#_CIK"));
                            _morphologicTypeList.Add(new MorphologicType("Ness", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("WithoutBeingAbleToHaveDoneSo", "Olmadan", " "));
                            _morphologicTypeList.Add(new MorphologicType("FeelLike", "Gibi hissediyorum", " "));
                            _morphologicTypeList.Add(new MorphologicType("WithoutHavingDoneSo", "Öylesine yapılmadan", " "));
                            _morphologicTypeList.Add(new MorphologicType("NotState", "Belirsiz", " "));
                            _morphologicTypeList.Add(new MorphologicType("interj", "Ünlem", " ha! ay! hoppala!"));
                            _morphologicTypeList.Add(new MorphologicType("Acro", "Kısaltma", " "));
                            _morphologicTypeList.Add(new MorphologicType("conj", "Bağlaç", " ve (and)"));
                            _morphologicTypeList.Add(new MorphologicType("Repeat", "Tekrar", " "));
                            _morphologicTypeList.Add(new MorphologicType("EverSince", "O zamandan beri", " olagelen. Usually together with a noun derivation suffix.  FIIL#_SURERLIK#_EGEL"));
                            _morphologicTypeList.Add(new MorphologicType("Pron", "Zamir", " ben, sen, o (I, you, he/she/it)"));
                            _morphologicTypeList.Add(new MorphologicType("dup", "İkileme", " fokur fokur, abuk subuk. Can be an Adj, Noun or Adv."));
                            _morphologicTypeList.Add(new MorphologicType("Stay", "Kalmak, durmak", " bak-akal-dım. FIIL#_SURERLIK#_EKAL. Maybe left out from parsing."));
                            _morphologicTypeList.Add(new MorphologicType("Since", "Dan beri", " gün-dür, saat-tir.  Only used with nouns describing time. (This suffix does not exist in Zemberek-2). Converts word to an Adverb. Oflazer posıbly mıstakenly does not parse “saattir” for this suffix."));
                            _morphologicTypeList.Add(new MorphologicType("FitFor", "İçin uygun", " "));
                            _morphologicTypeList.Add(new MorphologicType("NoHats", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("Abbr", "Kısaltma", " "));
                            _morphologicTypeList.Add(new MorphologicType("Quant", "Miktar", " "));
                            _morphologicTypeList.Add(new MorphologicType("Postp", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("Pcabl", "Mevcut, sürekli", " "));
                            _morphologicTypeList.Add(new MorphologicType("Almost", "Neredeyse", " düş-eyaz-dım"));
                            _morphologicTypeList.Add(new MorphologicType("Pcnom", "Mevcut sürekli nominal", " "));
                            _morphologicTypeList.Add(new MorphologicType("det", "Belirlemek, saptamak", " "));
                            _morphologicTypeList.Add(new MorphologicType("Demons", "Gösterme", " "));
                            _morphologicTypeList.Add(new MorphologicType("Start", "Başlangıç", " "));
                            _morphologicTypeList.Add(new MorphologicType("Pcdat", "", " "));
                            _morphologicTypeList.Add(new MorphologicType("Recip", "İşteş", " bak-ış-tınız , Only applies to some verbs."));
                            _morphologicTypeList.Add(new MorphologicType("Reflex", "Dönüşlü", " temzile-n-miş, giyinmiş. Only some verbs can get this suffix. This generates ambiguity with Passive for those words."));
                            _morphologicTypeList.Add(new MorphologicType("Pers", "Kişisel", " "));
                            _morphologicTypeList.Add(new MorphologicType("Pcins", "Sürekli esin kaynağı", " "));
                            _morphologicTypeList.Add(new MorphologicType("Ques", "Soru", " "));

                        }
                    }
                }

                return _morphologicTypeList;
            }
        }
    }



    public class MorphologicType
    {
        string _name;
        string _description;
        string _sample;
        string _form;

        public string Form
        {
            get
            {
                return _form;
            }

            set
            {
                _form = value;
            }
        }

        public string Sample
        {
            get
            {
                return _sample;
            }

            set
            {
                _sample = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }


        public MorphologicType()
        {

        }



        public MorphologicType(string name)
        {
            _name = name.Trim();
        }


        public MorphologicType(string name, string description):this(name)
        {
            _description = description.Trim();
        }

        public MorphologicType(string name, string description, string sample) : this(name, description)
        {
            _sample = sample.Trim();
        }


        public MorphologicType(string name, string description, string sample, string form) : this(name, description, sample)
        {
            _form = form;
        }
    }
}
