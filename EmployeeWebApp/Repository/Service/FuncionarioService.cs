using EmployeeWebApp.Models;
using EmployeeWebApp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Repository.Service
{
    public class FuncionarioService
    {
        private DataContext contexto { get; set; }

        public FuncionarioService(DataContext context)
        {
            contexto = context;
        }

        public List<Funcionario> GetFuncionario()
        {
            return contexto.Funcionarios.ToList();
        }

        public void CreateFuncionario(Funcionario funcionario)
        {
            contexto.Funcionarios.Add(funcionario);
            contexto.SaveChanges();
        }

        public void EditFuncionario(Funcionario funcionario, int id)
        {
            contexto.Entry(funcionario).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void DeleteFuncionario(Funcionario Funcionario, int id)
        {
            var funcionarioDelete = contexto.Funcionarios.Find(id);
            contexto.Funcionarios.Remove(funcionarioDelete);
            contexto.SaveChanges();
        }
    }
}