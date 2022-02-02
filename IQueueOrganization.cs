using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public interface IQueueOrganization
    {
        Queue FilaDeEntradas { get; set; }
        Queue FilaDeAcompanhamentos { get; set; }

        Queue FilaDeSobremesas { get; set; }

        Queue FilaDeBebidas { get; set; }

        Queue FilaDeCarnes { get; set; }
        Queue FilaDeMassas { get; set; }
        Queue FilaDeSaladas { get; set; }

        void QueueAdd(Item item);
    }
}
