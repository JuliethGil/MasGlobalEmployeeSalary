namespace DataAccess.Models
{
    using DataAccess.Interfaces;

    public class ResponseApi : IResponseQuery
    {
        #region Attributes
        public static IResponseQuery Interface { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        #endregion

        #region Constructors
        public static IResponseQuery GetInstance()
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new ResponseApi();
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
