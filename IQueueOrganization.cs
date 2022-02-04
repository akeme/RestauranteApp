using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public interface IQueueOrganization
    {
        Queue QueueOfFries { get; set; }
        Queue QueueOfGarnish { get; set; }

        Queue QueueOfDesert { get; set; }

        Queue QueueOfDrink { get; set; }

        Queue QueueOfGrill { get; set; }
        Queue QueueOfPasta { get; set; }
        Queue QueueOfSalad { get; set; }

        void QueueAdd(Item item);
    }
}
