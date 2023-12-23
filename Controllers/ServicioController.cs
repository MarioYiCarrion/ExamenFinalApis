using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly VeterinarioContext BD;
        public ServicioController(VeterinarioContext context)
        {
            BD = context;
        }

        //listar Servicios

        [HttpGet]
        public IEnumerable<Servicio> ListadeServicios()
        {
            return BD.Servicios.ToList();
        }

        //Crear Servicios
        [HttpPost]
        public IActionResult CreateServicios([FromBody] Servicio pservicio)
        {
            if (ModelState.IsValid)
            {
                BD.Servicios.Add(pservicio);
                BD.SaveChanges();

                return new CreatedAtRouteResult("ServicioCreado", new { ip = pservicio.ServicioId }, pservicio);
            }
            return BadRequest(ModelState);
        }

        //Modificar Servicio
        [HttpPut("{id}")]
        public IActionResult ModificarServicio([FromBody] Servicio servicio, int id)
        {
            if (servicio.ServicioId != id)
            {
                return BadRequest();
            }
            BD.Entry(servicio).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        //Eliminar Servicio

        [HttpDelete("{id}")]
        public IActionResult EliminarServicio(int id)
        {
            var servicio = BD.Servicios.FirstOrDefault(l => l.ServicioId == id);

            if (servicio == null)
            {
                return NotFound();
            }
            BD.Servicios.Remove(servicio);
            BD.SaveChanges();
            return Ok(servicio);
        }
    }
}
