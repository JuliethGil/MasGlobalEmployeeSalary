namespace DataAccess.Models
{
    using DataAccess.Interfaces;

    public class ResponseClient : IResponseClient
    {
        #region Attributes
        public static IResponseClient Interface { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        #endregion

        #region Constructors
        public static IResponseClient GetInstance()
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new ResponseClient();
        }
        #endregion

        #region Methods
        public void BadRequest(string message = null)
        {
            Message = string.IsNullOrEmpty(message) ? "Business mistake" : message;
            StatusCode = 400;
        }
        #endregion
    }
}
