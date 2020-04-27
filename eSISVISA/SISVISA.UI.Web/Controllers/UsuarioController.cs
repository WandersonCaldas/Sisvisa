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
    public class UsuarioController : Controller
    {
        private UsuarioRegra _regra = new UsuarioRegra();
        // GET: Usuario
        public ActionResult Index()
        {            
            return View(_regra.ListarUsuarios());
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario obj)
        {
            if (ModelState.IsValid)
            {
                Usuario retorno = new Usuario();
                retorno = _regra.IncluirUsuario(obj);
                if (retorno.status.Equals(ResponseStatus.SUCESSO.Texto))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, retorno.mensagem);
            }

            return View(obj);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_regra.ListarUsuarios().Where(x => x.cod_usuario == id).FirstOrDefault());
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario obj)
        {            
            if (ModelState.IsValid || obj.txt_senha == null)
            {
                Usuario retorno = new Usuario();
                retorno = _regra.AlterarUsuario(obj);
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