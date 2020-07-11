namespace ServiceAccessLayer.Services
{
    using DataAccess.Models;
    using ServiceAccessLayer.Constants;
    using ServiceAccessLayer.Interfaces;
    using System.Threading.Tasks;

    public class EmployeeService : IEmployeeService
    {
        #region Attributes
        private readonly ApiService apiService;
        public static IEmployeeService Interface { get; set; }
        #endregion

        #region Constructors
        public static IEmployeeService GetInstance()
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeService();
        }

        public EmployeeService()
        {
            apiService = new ApiService();
        }
        #endregion

        #region Methods
        public async Task<ResponseApi> GetEmployees()
        {
            var response = await apiService.GetList<Employee>(
               ConstantsService.UrlBase,
               ConstantsService.ServisePrefix,
               EndPointsContantsServices.Employees);
            return response;
        }
        #endregion
    }
}
