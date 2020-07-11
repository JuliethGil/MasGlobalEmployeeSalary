namespace MasGlobalEmployeeSalary.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using DataAccess.Models;
    using DataAccess.Interfaces;
    using DataAccess.Queries;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region Attributes
        private IEmployeeLogic employeeLogic;
        private IEmployeeQuery employeeQuery;
        private IResponseApiQuery responseApiQuery;
        private string errorMessage;
        #endregion

        #region Inicializer
        private void Inicializer()
        {
            employeeQuery = EmployeeQuery.GetInstance();
            employeeLogic = EmployeeLogic.GetInstance(employeeQuery);
            responseApiQuery = ResponseApi.GetInstance();
            errorMessage = null;
        }
        #endregion

        #region EndPoints
        [HttpGet]
        public IActionResult Get()
        {
            Inicializer();
            var employees = employeeLogic.GetAllEmployee();

            if (employees != null)
            {
                return Ok(JsonConvert.SerializeObject(employees, Formatting.Indented));
            }
            else
            {
                response.BadRequest(errorMessage);
                return BadRequest(JsonConvert.SerializeObject(response, Formatting.Indented));
            }
        }
        #endregion
    }
}
