using NLPEnvironment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlpAnalyseLibrary
{
    public static class AnalyseFactory
    {
        static List<INlpAnalyse> _analyseList;
        static object _locker = new object();

        public static List<INlpAnalyse> AnalyseList
        {
            get
            {
                if (_analyseList == null)
                {
                    lock (_locker)
                    {
                        if (_analyseList == null)
                        {
                            _analyseList = new List<INlpAnalyse>();

                            _analyseList.Add(new NlpAnalyseAddress.AnalyseAddress());
                        }
                    }
                }

                return _analyseList;
            }
        }

    }
}
