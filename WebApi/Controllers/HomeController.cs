using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CapaEntidad;
using CapaNegocio;

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public bool AgregarEmpleado()
        {
            return true;
        }

        [HttpGet]
        public IHttpActionResult getEmpleado()
        {
            return Json(EmpleadoBL.GetInstance().getEmpleado());
        }

        [HttpDelete]
        public string EliminarEmpleado(string id)
        {
            return "Empleado eliminado con id " + id;
        }
        [HttpPut]
        public string ActualizaEmpleado(string nombre, string ciudad)
        {
            return "Empleado actualizado con nombre: " + nombre + " y ciudad " + ciudad;
        }
    }
}
