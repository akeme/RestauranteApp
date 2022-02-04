using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public class QueueOrganization : IQueueOrganization
    {
        public Queue QueueOfFries { get; set; }
        public Queue QueueOfGarnish { get; set; }
        public Queue QueueOfDesert { get; set; }
        public Queue QueueOfDrink { get; set; }
        public Queue QueueOfGrill { get; set; }
        public Queue QueueOfPasta { get; set; }
        public Queue QueueOfSalad { get; set; }

        public void QueueManegement()
        {
            QueueOfFries = new Queue("Fries");
            QueueOfGarnish = new Queue("Garnish");
            QueueOfDesert = new Queue("Desert");
            QueueOfDrink = new Queue("Drink");
            QueueOfGrill = new Queue("Grill");
            QueueOfPasta = new Queue("Pasta");
            QueueOfSalad = new Queue("Salad");

        }
        public void QueueAdd(Item item)
        {
            switch (item.Responsable)
            {
                case AreaResponsable.Garnish:
                    QueueOfGarnish.Itens.Add(item);
                    break;
                case AreaResponsable.Fries:
                    QueueOfFries.Itens.Add(item);
                    break;
                case AreaResponsable.Drink:
                    QueueOfDrink.Itens.Add(item);
                    break;
                case AreaResponsable.Grill:
                    QueueOfGrill.Itens.Add(item);
                    break;
                case AreaResponsable.Pasta:
                    QueueOfPasta.Itens.Add(item);
                    break;
                case AreaResponsable.Salad:
                    QueueOfSalad.Itens.Add(item);
                    break;
                case AreaResponsable.Desert:
                    QueueOfDesert.Itens.Add(item);
                    break;
                default:
                    throw new NotImplementedException();
                    break;



            }

        }


    }
}
