using Entities.DTO.Address;
using Entities.Enums;

namespace Business.Helpers
{
    public static class UserAddressHelpers
    {
        public static AddressTypeDTO GetAddressType(int addressTypeId)
        {
            if (addressTypeId == (int)AddressTypeEnum.HOME)
                return new AddressTypeDTO { IconClassName = "fa fa-home", Name = "EV" };
            else if (addressTypeId == (int)AddressTypeEnum.WORK)
                return new AddressTypeDTO { IconClassName = "fa fa-briefcase", Name = "İŞ" };
            else
                return new AddressTypeDTO { IconClassName = "fa fa-info-circle", Name = "DİĞER" };
        }
    }
}