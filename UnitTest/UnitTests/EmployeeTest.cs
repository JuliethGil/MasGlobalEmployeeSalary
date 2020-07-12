namespace UnitTest.UnitTests
{
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using MasGlobalEmployeeSalary.Controllers;
    using NSubstitute;
    using ServiceAccessLayer.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnitTest.DataObjects;
    using Xunit;

    public class EmployeeTest
    {
        #region Attributes
        private readonly EmployeeController employeeController;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IResponseClient responseClient;
        private readonly IEmployeeService employeeService;
        private readonly IEmployeeQuery employeeQuery;
        #endregion

        #region Constructor
        public EmployeeTest()
        {
            employeeController = new EmployeeController();
            responseClient = Substitute.For<IResponseClient>();
            employeeService = Substitute.For<IEmployeeService>();
            employeeQuery = Substitute.For<IEmployeeQuery>();
            employeeLogic = new EmployeeLogic(employeeService, employeeQuery);
        }
        #endregion

        [Fact]
        public void GetAllEmployees()
        {
            //Arrange
            MockService();

            //Act
            var result = employeeLogic.GetEmployees(null);
            
            //Assert
            Assert.NotNull(result);
            Assert.True(result.Result.IsSuccess);
            Assert.Contains(result.Result.Message, "Success");
            Assert.True(((List<Employee>)result.Result.Result).Count > 0);
        }

        private void MockService()
        {
            List<Employee> employees = EmployeeDataObject.CreateEmployee();
            ResponseApi responseApi = EmployeeDataObject.CreateResponseApi(employees);

            employeeService.GetEmployees().Returns(Task.FromResult(responseApi));
        }
    }
}
