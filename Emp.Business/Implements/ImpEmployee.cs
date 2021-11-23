using Dapper;
using Emp.BDContext.Services;
using Emp.Business.Interfaces;
using Emp.Core;
using Emp.Core.General;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Emp.Business.Implements
{
    public class ImpEmployee : IEmployee
    {
        private readonly IDapper _dapper;

        public ImpEmployee(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<Result<Employee>> addEmployee(Employee emp)
        {

            Result<Employee> _result = new Result<Employee>();
            try
            {

          


            var dbparams = new DynamicParameters();

         
            dbparams.Add("@Nombre", emp.Nombre, DbType.String);
            dbparams.Add("@Apaterno", emp.APaterno, DbType.String);
            dbparams.Add("@AMaterno", emp.AMaterno, DbType.String);
            dbparams.Add("@FNacimiento", emp.FNacimiento, DbType.DateTime);
            dbparams.Add("@NumEmpleado", emp.NumEmpleado, DbType.Int64);
            dbparams.Add("@Curp", emp.Curp, DbType.String);
            dbparams.Add("@SSN", emp.SSN, DbType.String);
            dbparams.Add("@Telefono", emp.Telefono, DbType.String);
            dbparams.Add("@Nacionalidad", emp.Nacionalidad, DbType.Int32);

            _result = await Task.FromResult(_dapper.ExcuteSp<Employee>("[sp_addEmployee]", dbparams, commandType: CommandType.StoredProcedure));



           
            }
            catch (Exception ex)
            {

                _result.Mensaje = ex.Message;
            }
            return _result;
        }

        public async Task<Result<Employee>> delEmployee(Employee emp)
        {
            Result<Employee> _result = new Result<Employee>();
            try
            {




                var dbparams = new DynamicParameters();


                dbparams.Add("@idEmpleado", emp.idEmployee, DbType.Int64);
                

                _result = await Task.FromResult(_dapper.ExcuteSp<Employee>("[sp_DelEmployee]", dbparams, commandType: CommandType.StoredProcedure));




            }
            catch (Exception ex)
            {

                _result.Mensaje = ex.Message;
            }
            return _result;
        }

        public Task<Result<Employee>> getEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Employee>> lsEmployees()
        {

            Result<Employee> _result = new Result<Employee>();



            var dbparams = new DynamicParameters();

           

            _result = await Task.FromResult(_dapper.GetAll<Employee>("sp_EmployeesList", dbparams, commandType: CommandType.StoredProcedure));


            return _result;
        }

        public  async Task<Result<Employee>> updEmployee(Employee emp)
        {
            Result<Employee> _result = new Result<Employee>();
            try
            {




                var dbparams = new DynamicParameters();

                dbparams.Add("@idEmpleado", emp.idEmployee, DbType.Int64);
                dbparams.Add("@Nombre", emp.Nombre, DbType.String);
                dbparams.Add("@Apaterno", emp.APaterno, DbType.String);
                dbparams.Add("@AMaterno", emp.AMaterno, DbType.String);
                dbparams.Add("@FNacimiento", emp.FNacimiento, DbType.DateTime);
                dbparams.Add("@NumEmpleado", emp.NumEmpleado, DbType.Int64);
                dbparams.Add("@Curp", emp.Curp, DbType.String);
                dbparams.Add("@SSN", emp.SSN, DbType.String);
                dbparams.Add("@Telefono", emp.Telefono, DbType.String);
                dbparams.Add("@Nacionalidad", emp.Nacionalidad, DbType.Int32);

                _result = await Task.FromResult(_dapper.ExcuteSp<Employee>("[sp_UpdEmployee]", dbparams, commandType: CommandType.StoredProcedure));




            }
            catch (Exception ex)
            {

                _result.Mensaje = ex.Message;
            }
            return _result;
        }
    }
}
