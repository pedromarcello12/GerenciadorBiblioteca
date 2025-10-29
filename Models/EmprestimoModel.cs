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
            UsuarioId = idUsuario;
            LivroId = idLivro;
            DataEmprestimo = dataEmprestimo;
        }

        public int Id { get; set; }

        public int UsuarioId { get; set; }
        
        public int LivroId { get; set; }

        public  DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
