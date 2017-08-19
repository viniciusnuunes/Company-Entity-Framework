using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeWebApp.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string PrimeiroNome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string UltimoNome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyy}")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Nome da Empresa")]
        public int EmpresaID { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}