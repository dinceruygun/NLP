using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPEnvironment.Analyze;
using NLPEnvironment.Entities;
using NLPEnvironment.Interfaces;

namespace NlpAnalyseAddress.AddressControl
{
    public class AddressControlDistrict : IAddressControl
    {
        internal override bool Control(INlpAnalyzeIndex analyze, LineCollection lines, AnalyzeIndex index)
        {

            if (index.WordNumber >= lines[index.LineNumber].SentenceList[index.SentenceNumber].WordList.Count - 1) return false;

            var nextWord = lines[index.LineNumber].SentenceList[index.SentenceNumber].WordList[index.WordNumber + 1];

            if (nextWord.Root.Text.ToLower() == "mahalle")
            {
                return true;
            }
            else if (nextWord.Text.ToLower() == "mah")
            {
                return true;
            }
            else if (nextWord.Text.ToLower() == "mah.")
            {
                return true;
            }


            return false;
        }
    }
}
