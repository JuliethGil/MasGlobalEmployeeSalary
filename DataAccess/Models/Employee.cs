namespace DataAccess.Models
{
    using static DataAccess.Enumerators.ContractTypeEnumerator;

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary
        {
            get
            {
                return ContractType.HourlySalaryEmployee.ToString() == ContractTypeName
                   ? 120 * HourlySalary * 12
                   : MonthlySalary * 12;
            }
            set { }
        }
    }
}
