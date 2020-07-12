namespace MasGlobalEmployeeSalary.Controllers
{
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using DataAccess.Query;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using ServiceAccessLayer.Interfaces;
    using ServiceAccessLayer.Services;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region Attributes
        private IEmployeeLogic employeeLogic;
        private IResponseClient responseClient;
        private IEmployeeService employeeService;
        private IEmployeeQuery employeeQuery;
        private string errorMessage;
        #endregion

        #region Inicializer
        private void Inicializer()
        {
            employeeService = EmployeeService.GetInstance();
            employeeQuery = EmployeeQuery.GetInstance();
            employeeLogic = EmployeeLogic.GetInstance(employeeService, employeeQuery);
            responseClient = ResponseClient.GetInstance();
            errorMessage = null;
        }
        #endregion

        #region EndPoints
        [HttpGet()]
        public IActionResult Get(int? identity = null)
        {
            Inicializer();
            var employees = employeeLogic.GetEmployees(identity);

            if (employees.Result != null && employees.Result.IsSuccess.Equals(true))
            {
                return Ok(JsonConvert.SerializeObject(employees.Result.Result, Formatting.Indented));
            }
            else
            {
                responseClient.BadRequest(errorMessage);
                return BadRequest(JsonConvert.SerializeObject(responseClient, Formatting.Indented));
            }
        }
        #endregion
    }
}
