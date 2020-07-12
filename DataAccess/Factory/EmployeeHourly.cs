namespace DataAccess.Factory
{
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using static DataAccess.Enumerators.ContractTypeEnumerator;

    public class EmployeeHourly : ISalary
    {
        public static ISalary Interface { get; set; }
        public  Employee employee { get; set; }

        #region Constructors
        public static ISalary GetInstance(Employee employee)
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeHourly(employee);
        }

        public EmployeeHourly(Employee employee)
        {
            this.employee = employee;
        }
        #endregion

        #region Methods
        public bool ApplyInstance()
        {
            return ContractType.HourlySalaryEmployee.ToString() == employee.ContractTypeName;
        }

        public void AnnualSalary()
        {
            employee.AnnualSalary = this.employee.HourlySalary;
            employee.Salary = 120 * this.employee.HourlySalary * 12;
        }
        #endregion
    }
}
