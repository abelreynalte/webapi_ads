using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class EmpleadoBL
    {
        private static EmpleadoBL _Instance = null;
        private EmpleadoBL()
        {
        }
        public static EmpleadoBL GetInstance()
        {
            if (_Instance == null)
                _Instance = new EmpleadoBL();

            return _Instance;
        }

        public List<EmpleadoBE> getEmpleado()
        {
            return EmpleadoDA.GetInstance().getEmpleado();
        }
    }
}
