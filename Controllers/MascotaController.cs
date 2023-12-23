using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : Controller
    {
        private readonly VeterinarioContext BD;
        public MascotaController(VeterinarioContext context)
        {
            BD = context;
        }

        //listar Mascotas

        [HttpGet]
        public IEnumerable<Mascota> ListadeMascota()
        {
            return BD.Mascotas.ToList();
        }

        //Crear Mascota
        [HttpPost]
        public IActionResult CreateMascota([FromBody] Mascota pmascota)
        {
            if (ModelState.IsValid)
            {
                BD.Mascotas.Add(pmascota);
                BD.SaveChanges();

                return new CreatedAtRouteResult("MascotaCreada", new { ip = pmascota.MascotaId }, pmascota);
            }
            return BadRequest(ModelState);
        }

        //Modificar Mascota
        [HttpPut("{id}")]
        public IActionResult ModificarMascota([FromBody] Mascota mascota, int id)
        {
            if (mascota.MascotaId != id)
            {
                return BadRequest();
            }
            BD.Entry(mascota).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        //Eliminar Mascota

        [HttpDelete("{id}")]
        public IActionResult EliminarMascota(int id)
        {
            var mascota = BD.Mascotas.FirstOrDefault(l => l.MascotaId == id);

            if (mascota == null)
            {
                return NotFound();
            }
            BD.Mascotas.Remove(mascota);
            BD.SaveChanges();
            return Ok(mascota);
        }
    }
}
