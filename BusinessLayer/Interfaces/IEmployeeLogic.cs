namespace BusinessLayer.Interfaces
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IEmployeeLogic
    {
        List<Employee> GetAllEmployee();
    }
}
