using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : Controller
    {
        private readonly VeterinarioContext BD;
        public CitaController(VeterinarioContext context)
        {
            BD = context;
        }

        //listar Citas

        [HttpGet]
        public IEnumerable<Cita> ListadeCitas()
        {
            return BD.Citas.ToList();
        }

        //Crear Citas
        [HttpPost]
        public IActionResult CreateCitas([FromBody] Cita pcita)
        {
            if (ModelState.IsValid)
            {
                BD.Citas.Add(pcita);
                BD.SaveChanges();

                return new CreatedAtRouteResult("CitaCreada", new { ip = pcita.CitaId }, pcita);
            }
            return BadRequest(ModelState);
        }

        //Modificar Citas
        [HttpPut("{id}")]
        public IActionResult ModificarCita([FromBody] Cita cita, int id)
        {
            if (cita.CitaId != id)
            {
                return BadRequest();
            }
            BD.Entry(cita).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        //Eliminar Citas

        [HttpDelete("{id}")]
        public IActionResult EliminarCita(int id)
        {
            var cita = BD.Citas.FirstOrDefault(l => l.CitaId == id);

            if (cita == null)
            {
                return NotFound();
            }
            BD.Citas.Remove(cita);
            BD.SaveChanges();
            return Ok(cita);
        }
    }
}
