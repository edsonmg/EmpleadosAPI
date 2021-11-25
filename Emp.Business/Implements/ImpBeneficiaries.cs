using Dapper;
using Emp.BDContext.Services;
using Emp.Business.Interfaces;
using Emp.Core;
using Emp.Core.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.Business.Implements
{
    public class ImpBeneficiaries : IBeneficiaries
    {
        private readonly IDapper _dapper;

        public ImpBeneficiaries(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<Result<Beneficiaries>> addBeneficiaries(Beneficiaries ben)
        {
            Result<Beneficiaries> _result = new Result<Beneficiaries>();
            try
            {
                if (ben.Porcentaje <= 100)
                {
                    if (await ValidatePorcent(ben))
                    {



                        var dbparams = new DynamicParameters();

                        dbparams.Add("@idEmpleado", ben.idEmpleado, DbType.Int64);
                        dbparams.Add("@Nombre", ben.Nombre, DbType.String);
                        dbparams.Add("@Apaterno", ben.APaterno, DbType.String);
                        dbparams.Add("@AMaterno", ben.AMaterno, DbType.String);
                        dbparams.Add("@FNacimiento", ben.FNacimiento, DbType.DateTime);
                        dbparams.Add("@NumEmpleado", ben.NumEmpleado, DbType.Int64);
                        dbparams.Add("@Curp", ben.Curp, DbType.String);
                        dbparams.Add("@SSN", ben.SSN, DbType.String);
                        dbparams.Add("@Telefono", ben.Telefono, DbType.String);
                        dbparams.Add("@Nacionalidad", ben.Nacionalidad, DbType.Int32);
                        dbparams.Add("@Porcentaje", ben.Porcentaje, DbType.Decimal);

                        _result = await _dapper.ExcuteSp<Beneficiaries>("[sp_addbeneficiaries]", dbparams, commandType: CommandType.StoredProcedure);


                    }
                    else
                    {
                        _result.Exitoso = false;
                        _result.Mensaje = "La suma del porcentaje es mayor a 100";
                    }
                }
                else
                {
                    _result.Exitoso = false;
                    _result.Mensaje = "El porcentaje no debe ser mayor a  100";
                }

            }
            catch (Exception ex)
            {

                _result.Mensaje = ex.Message;
            }
            return _result;
        }

        public async Task<bool> ValidatePorcent(Beneficiaries ben)
        {
            Result<Beneficiaries> _result = new Result<Beneficiaries>();
            bool resp = false;


            var dbparams = new DynamicParameters();

            dbparams.Add("@idEmpleado", ben.idEmpleado, DbType.Int64);

            _result = await _dapper.GetAll<Beneficiaries>("sp_BeneficariesList", dbparams, commandType: CommandType.StoredProcedure);

            var porcentaje = _result.LsData.Sum(e => e.Porcentaje);
            var suma = porcentaje + ben.Porcentaje;
            if (suma <= 100)
            {
                resp = true;
            }

            return resp;
        }
    }
}
