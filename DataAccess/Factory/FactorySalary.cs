namespace DataAccess.Factory
{
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using System.Collections.Generic;

    public class FactorySalary
    {
        public static ISalary GetInstance(Employee employee)
        {
            EmployeeHourly employeeHourly = new EmployeeHourly(employee);
            EmployeeMonthly employeeMonthly = new EmployeeMonthly(employee);
            ISalary instance = null;

            List<ISalary> implemimplementations = new List<ISalary>
            {
                employeeHourly,
                employeeMonthly
            };

            foreach (ISalary implemimplementation in implemimplementations)
            {
                if (implemimplementation.ApplyInstance())
                {
                    instance = implemimplementation;
                    break;
                }
            }

            return instance;
        }
    }
}
