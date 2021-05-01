namespace UI.Models
{
    public class ToastModel<T>
    {
        public string Icon { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public T Data { get; set; }

        public static ToastModel<T> Success(string message) => new ToastModel<T> { Icon = "success", Title = "Başarılı", Message = message };
        public static ToastModel<T> Fail(string message) => new ToastModel<T> { Icon = "error", Title = "Ooops..", Message = message };
        public static ToastModel<T> Success(string message, T data) => new ToastModel<T> { Icon = "success", Title = "Başarılı", Message = message, Data = data };
        public static ToastModel<T> Fail(string message, T data) => new ToastModel<T> { Icon = "error", Title = "Ooops..", Message = message, Data = data };
    }
}