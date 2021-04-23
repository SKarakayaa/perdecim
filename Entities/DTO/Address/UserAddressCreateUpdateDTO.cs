using System.ComponentModel;

namespace Entities.DTO.Address
{
    public class UserAddressCreateUpdateDTO
    {
        public int Id { get; set; }

        [DisplayName("Şehir")]
        public int CityId { get; set; }

        [DisplayName("İlçe")]
        public int DistrictId { get; set; }

        [DisplayName("Mahalle")]
        public int NeighborhoodId { get; set; }

        [DisplayName("Adres Tipi")]
        public int AddressType { get; set; }

        [DisplayName("Açık Adres (Cadde,Sokak,Bina ve Kapı No)")]
        public string OpenAddress { get; set; }
    }
}