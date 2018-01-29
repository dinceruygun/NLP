using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Entities;

namespace NlpAnalyseLibrary
{
    public class AnalyseManager
    {
        public void Analyse(LineCollection lines)
        {
            if (lines == null) return;


            foreach (var a in AnalyseFactory.AnalyseList)
            {
                a.Analyse(lines);
            }
        }
    }
}
