using Agencia_API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ClienteDBContext _context;

        public ClienteController(ClienteDBContext context)
        {
            _context = context;
        }







        // GET: api/Cursos - LISTA TODOS OS CURSOS
        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes;
        }



        // CRIA UM NOVO CURSO
        [HttpPost]
        public IActionResult CriarCliente(Cliente item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Clientes.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }

        // ATUALIZA UM CURSO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, Cliente item)
        {
            if (id != item.ClienteId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();



            return new NoContentResult();
        }



        // APAGA UM CURSO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(m => m.ClienteId == id);


            if (cliente == null)
            {
                return BadRequest();
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }


        // GET: api/Cursos/id - LISTA CURSO POR ID
        [HttpGet("{id}")]
        public IActionResult GetClientePorId(int id)
        {
            Cliente cliente = _context.Clientes.SingleOrDefault(modelo => modelo.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return new ObjectResult(cliente);
        }

    }


}