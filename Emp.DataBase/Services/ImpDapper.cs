using Dapper;
using Emp.Core.General;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Emp.BDContext.Services
{
    public class ImpDapper : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "SQLAuth";

        public ImpDapper(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Result<T>> ExcuteSp<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            Result<T> result = new Result<T>();
            using (var conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                  
                    try
                    {
                        result.Data = await conn.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType, transaction: sqlTransaction);
                        sqlTransaction.Commit();
                        result.Exitoso = true;
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        result.Mensaje = ex.Message;
                        result.Exitoso = false;
                    }
                }
                catch (Exception ex)
                {
                    result.Mensaje = ex.Message;
                    result.Exitoso = false;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }


            return result;
        }

        public async Task<Result<T>> ExcuteStore<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            Result<T> result = new Result<T>();
            using (var conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                   
                    try
                    {
                        result.Data = await conn.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: commandType);
                        
                        result.Exitoso = true;
                    }
                    catch (Exception ex)
                    {
                      
                        result.Mensaje = ex.Message;
                        result.Exitoso = false;
                    }
                }
                catch (Exception ex)
                {
                    result.Mensaje = ex.Message;
                    result.Exitoso = false;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }


            return result;
        }


        async Task<Result<T>> IDapper.Get<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            Result<T> result = new Result<T>();

                try
                {

                using (var conn = new SqlConnection(this._config.GetConnectionString(Connectionstring)))

                    result.Data = await conn.QueryFirstAsync<T>(sp, parms, commandType: commandType);
                    result.Exitoso = true;

                }
                catch (Exception ex)
                {

                    result.Mensaje = ex.Message;
                    result.Exitoso = false;
                }
               

            return result;
        }

        async Task<Result<T>> IDapper.GetAll<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            Result<T> result = new Result<T>();
            using (var conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                try
                {

                  
                    result.LsData = (System.Collections.Generic.List<T>) await conn.QueryAsync<T>(sp, parms, commandType: commandType);
                    result.Exitoso = true;
                }
                catch (Exception ex)
                {

                    result.Mensaje = ex.Message;
                    result.Exitoso = false;
                }
               
            return result;

        }

     
    }
}
