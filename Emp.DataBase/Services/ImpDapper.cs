using Dapper;
using Emp.Core.General;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public Result<T> ExcuteSp<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
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
                        result.Data = conn.Query<T>(sp, parms, commandType: commandType, transaction: sqlTransaction).FirstOrDefault();
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

        public Result<T> ExcuteStore<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            Result<T> result = new Result<T>();
            using (var conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                   
                    try
                    {
                        result.Data = conn.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
                        
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


        Result<T> IDapper.Get<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            Result<T> result = new Result<T>();

                try
                {

                using (var conn = new SqlConnection(this._config.GetConnectionString(Connectionstring)))

                    result.Data = conn.QueryFirstAsync<T>(sp, parms, commandType: commandType).Result;
                    result.Exitoso = true;

                }
                catch (Exception ex)
                {

                    result.Mensaje = ex.Message;
                    result.Exitoso = false;
                }
               

            return result;
        }

        Result<T> IDapper.GetAll<T>(string sp, DynamicParameters parms, CommandType commandType)
        {
            Result<T> result = new Result<T>();
            using (var conn = new SqlConnection(_config.GetConnectionString(Connectionstring)))
                try
                {

                  
                    result.LsData = conn.QueryAsync<T>(sp, parms, commandType: commandType).Result.ToList();
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
