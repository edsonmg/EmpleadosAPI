using Dapper;
using Emp.Core.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.BDContext.Services
{
    public interface IDapper
    {


        Task<Result<T>> Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<Result<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<Result<T>> ExcuteSp<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<Result<T>> ExcuteStore<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);


    }
}
