namespace DataAccess.Interfaces
{
    using DataAccess.Models;
    using System.Collections.Generic;

   public interface IEmployeeQuery
    {
        List<Employee> GetAllEmployee();
    }
}
