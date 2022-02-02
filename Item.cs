using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Name { get; set; }
        public AreaResponsable Responsable { get; set; }
    }
}
