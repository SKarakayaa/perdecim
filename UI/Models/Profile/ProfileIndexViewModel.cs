using System.ComponentModel;

namespace UI.Models.Profile
{
    public class ProfileIndexViewModel
    {
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefon Numarası")]
        public string Phone { get; set; }

        [DisplayName("Email Onayı")]
        public bool IsEmailConfirm { get; set; }

        [DisplayName("Ad Soyad")]
        public string FullName { get; set; }
    }
}