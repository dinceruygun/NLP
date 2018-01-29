using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Entities;

namespace NLPEnvironment.Interfaces
{
    public abstract class INlpAnalyse
    {
        public abstract void Analyse(LineCollection lines);
    }
}
