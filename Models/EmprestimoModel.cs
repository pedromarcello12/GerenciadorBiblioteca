using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciadorBiblioteca.Models
{
    public class EmprestimoModel
    {
        public EmprestimoModel()
        {
        }

        public EmprestimoModel(int id, int idUsuario, int idLivro, DateTime dataEmprestimo)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = dataEmprestimo;
        }

        public int Id { get; set; }

        public int IdUsuario { get; set; }
        
        public int IdLivro { get; set; }

        public  DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
