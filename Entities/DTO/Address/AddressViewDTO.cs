namespace Entities.DTO.Address
{
    public class AddressViewDTO
    {
        public int AddressId { get; set; }
        public AddressTypeDTO AddressType { get; set; }
        public string FullAddress { get; set; }
    }
}