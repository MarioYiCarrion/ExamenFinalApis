using ExamenFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly VeterinarioContext BD;
        public ClienteController(VeterinarioContext context)
        {
            BD = context;
        }

        //listar Clientes

        [HttpGet]
        public IEnumerable<Cliente> ListadeCliente()
        {
            return BD.Clientes.ToList();
        }

        //Crear Citas
        [HttpPost]
        public IActionResult CreateCliente([FromBody] Cliente pcliente)
        {
            if (ModelState.IsValid)
            {
                BD.Clientes.Add(pcliente);
                BD.SaveChanges();

                return new CreatedAtRouteResult("ClienteCreado", new { ip = pcliente.ClienteId }, pcliente);
            }
            return BadRequest(ModelState);
        }

        //Modificar Clientes
        [HttpPut("{id}")]
        public IActionResult ModificarCliente([FromBody] Cliente cliente, int id)
        {
            if (cliente.ClienteId != id)
            {
                return BadRequest();
            }
            BD.Entry(cliente).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        //Eliminar Clientes

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = BD.Clientes.FirstOrDefault(l => l.ClienteId == id);

            if (cliente == null)
            {
                return NotFound();
            }
            BD.Clientes.Remove(cliente);
            BD.SaveChanges();
            return Ok(cliente);
        }
    }


}
