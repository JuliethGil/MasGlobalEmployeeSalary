namespace MasGlobalEmployeeSalary.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using DataAccess.Models;
    using DataAccess.Interfaces;
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
        private string errorMessage;
        #endregion

        #region Inicializer
        private void Inicializer()
        {
            employeeService = EmployeeService.GetInstance();
            employeeLogic = EmployeeLogic.GetInstance(employeeService);
            responseClient = ResponseClient.GetInstance();
            errorMessage = null;
        }
        #endregion

        #region EndPoints
        [HttpGet]
        public IActionResult Get()
        {
            Inicializer();
            var employees = employeeLogic.GetEmployees();

            if (employees.Result != null && employees.Result.IsSuccess.Equals(true))
            {
                return Ok(JsonConvert.SerializeObject(employees.Result, Formatting.Indented));
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
