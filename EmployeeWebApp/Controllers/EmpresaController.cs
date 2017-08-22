using EmployeeWebApp.Models;
using EmployeeWebApp.Repository.Context;
using EmployeeWebApp.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebApp.Controllers
{
    public class EmpresaController : Controller
    {
        private DataContext contexto = new DataContext();
        private EmpresaService service = new EmpresaService(new DataContext());

        // GET: Empresa
        public ActionResult Index()
        {
            return View(service.GetEmpresas());
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // GET
        public ActionResult Edit(int id)
        {
            var query = (from e in contexto.Empresas
                         where e.EmpresaID == id
                         select e).FirstOrDefault();
            return View(query);
        }
        
        // GET
        public ActionResult Delete(int id)
        {
            var query = (from e in contexto.Empresas
                         where e.EmpresaID == id
                         select e).FirstOrDefault();
            return View(query);
        }
        
        // GET
        public ActionResult Details(Empresa empresa, int id)
        {
            var query = (from e in contexto.Empresas
                         where e.EmpresaID == id
                         select e).FirstOrDefault();
            return View(query);
        }

        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.CreateEmpresa(empresa);
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Tente novamente");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Empresa empresa, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.EditEmpresa(empresa, id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Tente novamente");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Empresa empresa, int id)
        {
            try
            {
                service.DeleteEmpresa(empresa, id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Tente novamente.");
            }
            return View("Index");
        }
    }
}