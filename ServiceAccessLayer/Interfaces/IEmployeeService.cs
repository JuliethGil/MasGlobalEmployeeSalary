namespace ServiceAccessLayer.Interfaces
{
    using DataAccess.Models;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<ResponseApi> GetEmployees();
    }
}
