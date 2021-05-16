using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum AddressTypeEnum
    {
        [Display(Name = "EV")]
        HOME = 1,

        [Display(Name = "İŞ")]
        WORK = 2,

        [Display(Name = "DİĞER")]
        OTHER = 3
    }
}
