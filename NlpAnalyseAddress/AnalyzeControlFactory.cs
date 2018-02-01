
using NlpAnalyseAddress.AnalyzeControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlpAnalyseAddress
{
    public static class AnalyzeControlFactory
    {
        public static IAnalyzeControl GetControl(AddressTypeEnum addressType)
        {
            switch (addressType)
            {
                case AddressTypeEnum.NONE:
                    return null;
                case AddressTypeEnum.COUNTRY:
                    break;
                case AddressTypeEnum.PROVINCE:
                    break;
                case AddressTypeEnum.CITY:
                    break;
                case AddressTypeEnum.DISTRICT:
                    return new AnalyzeControlDistrict();
                default:
                    break;
            }


            return null;
        }
    }
}
