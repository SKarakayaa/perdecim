using System.ComponentModel;

namespace Entities.DTO.Profile
{
    public class ChangePasswordDTO
    {
        [DisplayName("Mevcut Şifreniz")]
        public string CurrentPassword { get; set; }
        
        [DisplayName("Yeni Şifreniz")]
        public string NewPassword { get; set; }
        
        [DisplayName("Yeni Şifrenizi Tekrar Giriniz")]
        public string NewPasswordConfirm { get; set; }
    }
}