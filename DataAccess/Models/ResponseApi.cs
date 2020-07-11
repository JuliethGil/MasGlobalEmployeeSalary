namespace DataAccess.Models
{
    public class ResponseApi
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}
