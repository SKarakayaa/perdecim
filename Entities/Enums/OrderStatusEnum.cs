using System.ComponentModel.DataAnnotations;

namespace Entities.Enums
{
    public enum OrderStatusEnum
    {
        [Display(Name = "SİPARİŞ VERİLDİ")]
        ORDERED = 1,

        [Display(Name = "ONAYLANDI")]
        CONFIRMED = 2,

        [Display(Name = "YOLDA")]
        SENDED = 3,

        [Display(Name = "TAMAMLANDI")]
        COMPLETED = 4,

        [Display(Name = "İPTAL EDİLDİ")]
        CANCELED = 5
    }
}
