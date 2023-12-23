using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialMedicoController : Controller
    {
        private readonly VeterinarioContext BD;
        public HistorialMedicoController(VeterinarioContext context)
        {
            BD = context;
        }

        //listar Historial

        [HttpGet]
        public IEnumerable<HistorialMedico> ListadeHistorial()
        {
            return BD.HistorialMedicos.ToList();
        }

        //Crear Historial
        [HttpPost]
        public IActionResult CreateHistorial([FromBody] HistorialMedico phistorial)
        {
            if (ModelState.IsValid)
            {
                BD.HistorialMedicos.Add(phistorial);
                BD.SaveChanges();

                return new CreatedAtRouteResult("HistoriaCreada", new { ip = phistorial.HistorialId }, phistorial);
            }
            return BadRequest(ModelState);
        }

        //Modificar Hisrtorial
        [HttpPut("{id}")]
        public IActionResult ModificarHistorial([FromBody] HistorialMedico historial, int id)
        {
            if (historial.HistorialId != id)
            {
                return BadRequest();
            }
            BD.Entry(historial).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        //Eliminar Citas

        [HttpDelete("{id}")]
        public IActionResult EliminarHistorial(int id)
        {
            var historial = BD.HistorialMedicos.FirstOrDefault(l => l.HistorialId == id);

            if (historial == null)
            {
                return NotFound();
            }
            BD.HistorialMedicos.Remove(historial);
            BD.SaveChanges();
            return Ok(historial);
        }
    }
}
