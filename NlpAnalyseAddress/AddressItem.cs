using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Entities;
using NLPEnvironment.Interfaces;

namespace NlpAnalyseAddress
{
    public class AddressItem: INlpAnalyzeIndex
    {
        public AddressTypeEnum AddressType { get; internal set; }
    }
}
