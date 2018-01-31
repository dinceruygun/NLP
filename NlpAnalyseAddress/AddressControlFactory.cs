using NlpAnalyseAddress.AddressControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlpAnalyseAddress
{
    public static class AddressControlFactory
    {
        public static IAddressControl GetControl(AddressTypeEnum addressType)
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
                    return new AddressControlDistrict();
                default:
                    break;
            }


            return null;
        }
    }
}
