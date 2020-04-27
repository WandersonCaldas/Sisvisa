using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISVISA.Core.Regra;
using SISVISA.Core.Models;
using SISVISA.Core.Response;

namespace SISVISA.UI.Web.Controllers
{
    public class TermoController : Controller
    {
        private TermoRegra _regra = new TermoRegra();
        // GET: Termo
        public ActionResult Index()
        {            
            return View(_regra.ListarTermos());
        }

        // GET: Termo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Termo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Termo obj)
        {
            if (ModelState.IsValid)
            {
                Termo retorno = new Termo();
                retorno = _regra.IncluirTermo(obj);
                if (retorno.status.Equals(ResponseStatus.SUCESSO.Texto))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, retorno.mensagem);
            }

            return View(obj);
        }

        // GET: Termo/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_regra.ListarTermos().Where(x => x.cod_termo == id).FirstOrDefault());
        }

        // POST: Termo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Termo obj)
        {            
            if (ModelState.IsValid)
            {
                Termo retorno = new Termo();
                retorno = _regra.AlterarTermo(obj);
                if (retorno.status.Equals(ResponseStatus.SUCESSO.Texto))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, retorno.mensagem);
            }            
            return View(obj);
        }
    }
}