
using Microsoft.AspNetCore.Mvc;
using PROJETOMVC.Context;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public IActionResult Criar()
        {
            return View();
        }
    }
}