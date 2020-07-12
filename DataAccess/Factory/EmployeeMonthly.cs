namespace DataAccess.Factory
{
    using DataAccess.Interfaces;
    using DataAccess.Models;
    using static DataAccess.Enumerators.ContractTypeEnumerator;

    public class EmployeeMonthly :  ISalary
    {
        public static ISalary Interface { get; set; }
        private Employee employee { get; set; }

        #region Constructors
        public static ISalary GetInstance(Employee employee)
        {
            if (Interface != null)
            {
                return Interface;
            }

            return new EmployeeMonthly(employee);
        }

        public EmployeeMonthly(Employee employee)
        {
            this.employee = employee;
        }
        #endregion

        #region Methods
        public bool ApplyInstance()
        {
            return ContractType.MonthlySalaryEmployee.ToString() == this.employee.ContractTypeName;
        }

        public void AnnualSalary()
        {
            this.employee.Salary = this.employee.MonthlySalary;
            this.employee.AnnualSalary = this.employee.MonthlySalary * 12;
        }
        #endregion
    }
}
