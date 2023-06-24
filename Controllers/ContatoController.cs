
using Microsoft.AspNetCore.Mvc;
using PROJETOMVC.Context;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PROJETOMVC.Models;

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


        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
           if(ModelState.IsValid)
           {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           }
           return View(contato);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            
            if(contato == null)
            return NotFound();
            
            return View(contato);

        }


        
        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            
            var contatoBanco = _context.Contatos.Find(contato.id);
            
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        
        public IActionResult Detalhes(int id)

        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            return RedirectToAction(nameof(Index));

            return View(contato);
        }
    }
}