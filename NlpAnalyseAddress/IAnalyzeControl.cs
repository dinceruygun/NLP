using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Analyze;
using NLPEnvironment.Entities;
using NLPEnvironment.Interfaces;

namespace NlpAnalyseAddress
{
    public abstract class IAnalyzeControl
    {
        internal abstract bool Control(INlpAnalyzeIndex analyze, LineCollection lines, AnalyzeIndex index);
    }
}
