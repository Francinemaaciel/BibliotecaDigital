using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEmprestimo.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        
        public string Descricao { get; set; }
        public bool Disponivel { get; set; } = true;

        public int Ano {  get; set; }
    }
}
