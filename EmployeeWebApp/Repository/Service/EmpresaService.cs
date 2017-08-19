using EmployeeWebApp.Models;
using EmployeeWebApp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Repository.Service
{
    public class EmpresaService
    {
        private DataContext contexto { get; set; }

        public EmpresaService(DataContext context)
        {
            contexto = context;
        }

        public List<Empresa> GetEmpresas()
        {
            return contexto.Empresas.ToList();
        }

        public void CreateEmpresa(Empresa empresa)
        {
            contexto.Empresas.Add(empresa);
            contexto.SaveChanges();
        }

        public void EditEmpresa(Empresa empresa, int id)
        {
            contexto.Entry(empresa).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void DeleteEmpresa(Empresa empresa, int id)
        {
            var empresaDelete = contexto.Empresas.Find(id);
            contexto.Empresas.Remove(empresaDelete);
            contexto.SaveChanges();
        }
    }
}