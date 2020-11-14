using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SegundoParcial.Entities;
using Microsoft.EntityFrameworkCore;

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
        public ReponseJava GetProveedor(string Nit, int Codigo, DateTime Nacimiento, DateTime Cobertura)
        {
            var baseItem = _context.ReponseJava.FromSqlRaw("EXEC Final.ConsultaProveedor @codigo = {0} ,@nit = {1}, @nacimiento = {2}, @cobertura = {3}", Codigo, Nit, Nacimiento, Cobertura).ToList();

            return baseItem.First();
        }

        [HttpGet("{Codigo}/{Nacimiento}")]
        public ReponseJava GetAfiliado(int Codigo, DateTime Nacimiento)
        {
            var baseItem = _context.ReponseJava.FromSqlRaw("EXEC Final.ConsultaAfiliado @codigo = {0} ,@nacimiento = {1}", Codigo, Nacimiento).ToList();

            return baseItem.First();
        }

    }
}
