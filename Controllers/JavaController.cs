using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SegundoParcial.Entities;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class JavaController : ControllerBase
{
        private readonly AppDBContext _context;

        public JavaController(AppDBContext context)
        {
            _context = context;
        }
        // GET: api/Facturas/5
        [HttpGet("{Nit}/{Codigo}/{Nacimiento}/{Cobertura}")]
        public  ReponseJava GetProveedor(string Nit, int Codigo, DateTime Nacimiento, DateTime Cobertura)
        {
            var Respuesta = new ReponseJava();
            Respuesta.Autorizacion = 1;
            Respuesta.Mensage = "Sin Cobertura";

            return  Respuesta;
        }

        [HttpGet("{Codigo}/{Cobertura}")]
        public ReponseJava GetAfiliado(int Codigo, DateTime Cobertura)
        {
            var Respuesta = new ReponseJava();
            Respuesta.Estado = "Activo";
            Respuesta.Deducible = 1500;
            Respuesta.TotalAcumulado = 24389;
            Respuesta.Pendiente = 870;

            return Respuesta;
        }

    }
}
