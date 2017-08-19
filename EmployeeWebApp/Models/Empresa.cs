using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }

        [Required]
        [Display(Name = "Nome da Empresa")]
        public string NomeDaEmpresa { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}