namespace UI.Models
{
    public class ToastModel
    {
        public string Icon { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public static ToastModel Success(string message) => new ToastModel { Icon = "success", Title = "Başarılı", Message = message };
        public static ToastModel Fail(string message) => new ToastModel { Icon = "error", Title = "Ooops..", Message = message };
    }
}