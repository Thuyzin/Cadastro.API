using System;

namespace Cadastro.Models
{
    public class Pessoa
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Nascimento { get; set; }

        public Boolean Situacao { get; set; }

        public int Nacionalidade { get; set; }

        public string Rg { get; set; }
        
        public string Passaporte { get; set; }
        public int Idade { get; internal set; }
    }
}
