using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public class Queue
    {
        public string Nome { get; set; }
        public IList<Item> Itens { get; set; }

        public Queue(string nome)
        {
            Nome = nome;
            Itens = new List<Item>();
        }
    }
}
