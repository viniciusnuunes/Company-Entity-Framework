using EmployeeWebApp.Models;
using EmployeeWebApp.Repository.Context;
using EmployeeWebApp.Repository.Service;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebApp.Controllers
{
    public class FuncionarioController : Controller
    {
        private DataContext contexto = new DataContext();
        private FuncionarioService service = new FuncionarioService(new DataContext());

        // GET: Funcionario
        public ActionResult Index()
        {
            var funcionarios = contexto.Funcionarios.Include(f => f.Empresa);
            return View(funcionarios.ToList());
        }

        // GET
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(contexto.Empresas, "EmpresaID", "NomeDaEmpresa");
            return View();
        }

        // GET
        public ActionResult Edit(int id)
        {
            var query = (from f in contexto.Funcionarios.Include(f => f.Empresa)
                         where f.FuncionarioID == id
                         select f).FirstOrDefault();
            ViewBag.EmpresaID = new SelectList(contexto.Empresas, "EmpresaID", "NomeDaEmpresa", query.EmpresaID);            
            return View(query);
        }

        // GET
        public ActionResult Delete(Funcionario funcionario, int id)
        {
            var query = (from f in contexto.Funcionarios
                         where f.FuncionarioID == id
                         select f).FirstOrDefault();
            return View(query);
        }

        // GET
        public ActionResult Details(Funcionario funcionario, int id)
        {
            var query = (from f in contexto.Funcionarios
                         where f.FuncionarioID == id
                         select f).FirstOrDefault();
            return View(query);
        }

        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.CreateFuncionario(funcionario);
                    return RedirectToAction("Index");
                }
                ViewBag.EmpresaID = new SelectList(contexto.Empresas, "EmpresaID", "NomeDaEmpresa", funcionario.EmpresaID);
                return View(funcionario);
            }
            catch
            {
                ModelState.AddModelError("", "Tente novamente");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Funcionario funcionario, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.EditFuncionario(funcionario, id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Tente novamente.");
            }
            return View();
        }
    }
}