namespace DataAccess.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public void BadRequest(string message = null)
        {
            Message = string.IsNullOrEmpty(message) ? "Business mistake" : message;
            StatusCode = 400;
        }
    }
}
