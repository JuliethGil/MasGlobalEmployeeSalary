namespace UnitTest.DataObjects
{
    using DataAccess.Models;
    using System.Collections.Generic;

    public static class EmployeeDataObject
    {
        public static ResponseApi CreateResponseApi(List<Employee> employees)
        {
            ResponseApi responseApi = new ResponseApi();
            responseApi.Message = "Success";
            responseApi.IsSuccess = true;
            responseApi.Result = employees;

            return responseApi;
        }

        public static List<Employee> CreateEmployee()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = null,
                HourlySalary = 60000,
                MonthlySalary = 80000
            };

            List<Employee> employees = new List<Employee>();
            employees.Add(employee);

            return employees;
        }
    }
}

