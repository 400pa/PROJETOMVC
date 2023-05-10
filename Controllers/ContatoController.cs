
using Microsoft.AspNetCore.Mvc;
using PROJETOMVC.Context;

namespace PROJETOMVC.Controllers
{
    public class ContatoController : Controller
    {
       
       private readonly AgendaContext _context;
       public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }
    }
}