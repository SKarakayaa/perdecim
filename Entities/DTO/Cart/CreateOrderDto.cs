using System.Collections.Generic;
using Entities.DTO.Address;

namespace Entities.DTO.Cart
{
    public class CreateOrderDto
    {
        public int AddressId { get; set; }
        public int PaymentType { get; set; }

        public List<AddressViewDTO> UserAddresses { get; set; }
        public List<PaymentTypeDto> PaymentTypes = GetList();

        public static List<PaymentTypeDto> GetList()
        {
            List<PaymentTypeDto> paymentTypes = new List<PaymentTypeDto>();

            paymentTypes.Add(new PaymentTypeDto { Id = 1, Name = "KAPIDA ÖDEME", ClassName = "fa fa-money", Description = "Siparişinizi Kapıda Ödeyerek Tamamlayın !" });
            paymentTypes.Add(new PaymentTypeDto { Id = 2, Name = "HAVALE/EFT", ClassName = "fa fa-credit-card", Description = "Mail Adresinize Gönderilecek Olan IBAN Numarasına Sipariş Ücretinizi Gönderebilirsiniz !" });

            return paymentTypes;
        }
    }
}