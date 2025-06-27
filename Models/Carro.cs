using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Carro
    {
        public string ImagemUrl { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string LinkUrl { get; set; } // Opcional, para o botão "Ir para algum lugar"
    }
}