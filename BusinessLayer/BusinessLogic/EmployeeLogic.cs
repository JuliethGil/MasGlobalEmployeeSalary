namespace BusinessLayer.BusinessLogic
{
    using BusinessLayer.Interfaces;
    using DataAccess.Models;
    using ServiceAccessLayer.Interfaces;
    using System.Threading.Tasks;

    public class EmployeeLogic : IEmployeeLogic
    {
        #region Attributes
        public static IEmployeeLogic Interface { get; set; }
        private readonly IEmployeeService employeeService;
        #endregion

        #region Constructors
        public static IEmployeeLogic GetInstance(IEmployeeService employeeService)
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeLogic(employeeService);
        }

        public EmployeeLogic(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        #endregion

        #region Interface Methods 
        public async Task<ResponseApi> GetEmployees()
        {
            var response = await employeeService.GetEmployees();
            return response;
        }
        #endregion
    }
}
