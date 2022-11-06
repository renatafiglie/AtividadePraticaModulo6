using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia_Viagens.Controllers
{
    public class ClienteController : Controller
    {

        //CÓDIGO ENVIADO PELO PROFESSOR
        private readonly ClienteDBContext _context;

        public ClienteController(ClienteDBContext context)
        {
            _context = context;
        }

        //ADICIONAR CÓDIGO
        public IActionResult Index()
        {
            return View(_context.Cliente.ToList());
        }
        //CÓDIGO ENVIADO PELO PROFESSOR.. em ''create'', criar uma exibição 
        // GET: Clientes/Create
        public IActionResult Create()
        {

            return View();

        }
        //ENVIADO PELO PROFESSOR  // recebe dados do formulário
        [HttpPost]
        public IActionResult Create([Bind("ClienteId,Nome,DataNascimento,Origem,Destino,DataIda,DataVolta")] Cliente cliente)




        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }


        // GET: Clientes/Edit/5 //
        public IActionResult Edit(int? id)
        {

            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = _context.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }


        //MÉTODO EXCLUIR
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = _context.Cliente.FirstOrDefault(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View();
        }

        //MÉTODO DETALHAR
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }


            var cliente = _context.Cliente.FirstOrDefault(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }


            return View();
        }





        [HttpPost] //MÉTODO EDITAR 
        public IActionResult Edit(int id, [Bind("ClienteId,Nome,DataNascimento,Origem,Destino,DataIda,DataVolta")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ClienteExists(cliente.ClienteoId))
                    // {
                    //     return NotFound();
                    //  }
                    //  else
                    //  {
                    //      throw;
                    //   }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }



        //MÉTODO EXCLUIR
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'ClienteDBContext.Cliente'  is null.");
            }
            var cliente = _context.Cliente.Find(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
