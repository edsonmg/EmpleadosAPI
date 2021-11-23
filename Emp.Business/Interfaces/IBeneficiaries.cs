using Emp.Core;
using Emp.Core.General;
using System.Threading.Tasks;

namespace Emp.Business.Interfaces
{
    public interface IBeneficiaries
    {
        Task<Result<Beneficiaries>> addBeneficiaries(Beneficiaries ben);
    }
}
