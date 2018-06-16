using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
//using System.Data.OracleClient;
using CapaEntidad;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public class EmpleadoDA
    {
        string oracle = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        private static EmpleadoDA _Instance = null;
        private EmpleadoDA()
        {
        }
        public static EmpleadoDA GetInstance()
        {
            if (_Instance == null)
                _Instance = new EmpleadoDA();

            return _Instance;
        }

        public List<EmpleadoBE> getEmpleado()
        {

            using (OracleConnection ora = new OracleConnection(oracle))
            {
                List<EmpleadoBE> lista = new List<EmpleadoBE>();
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = ora;
                objCmd.CommandText = "human_resources.get_employee";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("cur_employees", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                try
                {
                    ora.Open();
                    OracleDataReader objReader = objCmd.ExecuteReader();
                    EmpleadoBE obj;
                    while (objReader.Read())
                    {
                        obj = new EmpleadoBE();
                        obj.EmpNo = Convert.ToInt32(objReader["EmpNo"]);
                        obj.EName = objReader["EName"].ToString();
                        obj.Job = objReader["Job"].ToString();

                        lista.Add(obj);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Exception: {0}", ex.ToString());
                }

                ora.Close();

                return lista;
            }
        }
    }
}
