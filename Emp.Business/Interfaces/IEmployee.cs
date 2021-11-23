using Emp.Core;
using Emp.Core.General;
using System.Threading.Tasks;

namespace Emp.Business.Interfaces
{
    public interface IEmployee
    {
        Task<Result<Employee>> lsEmployees();
        Task<Result<Employee>> getEmployee(int Id);
        Task<Result<Employee>> updEmployee( Employee emp);
        Task<Result<Employee>> addEmployee(Employee emp );
        Task<Result<Employee>> delEmployee(Employee emp );
    }
}
