namespace BusinessLayer.Interfaces
{
    using DataAccess.Models;
    using System.Threading.Tasks;

    public interface IEmployeeLogic
    {
        Task<ResponseApi> GetEmployees(int? identity);
    }
}
