namespace MasGlobalEmployeeSalary.Controllers
{
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using BusinessLayer.BusinessLogic;
    using Newtonsoft.Json;
    using DataAccess.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        #region Attributes
        private IEmployeeLogic employeeLogic;
        private Response response;
        private string errorMessage;
        #endregion

        #region Inicializer
        private void Inicializer()
        {
            employeeLogic = new EmployeeLogic();
            response = new Response();
            errorMessage = null;
        }
        #endregion

        [HttpGet]
        public IActionResult Get()
        {
            Inicializer();
            var employees = employeeLogic.GetAllEmploy();

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
    }
}
