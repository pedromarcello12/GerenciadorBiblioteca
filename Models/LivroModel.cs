using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciadorBiblioteca.Models
{
    public class LivroModel
    {

        public LivroModel(int id, string titulo, string autor, string? iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get; set; }

        public  string Titulo { get; set; }

        public  string Autor { get; set; }

        public string? ISBN { get; set; }

        public int AnoPublicacao { get; set; }
    }
}
