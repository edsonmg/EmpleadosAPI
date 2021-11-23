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


        Result<T> Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Result<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Result<T> ExcuteSp<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Result<T> ExcuteStore<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);


    }
}
