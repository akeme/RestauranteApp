using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteApp
{
    public class QueueOrganization : IQueueOrganization
    {
        public Queue FilaDeEntradas { get; set; }
        public Queue FilaDeAcompanhamentos { get; set; }
        public Queue FilaDeSobremesas { get; set; }
        public Queue FilaDeBebidas { get; set; }
        public Queue FilaDeCarnes { get; set; }
        public Queue FilaDeMassas { get; set; }
        public Queue FilaDeSaladas { get; set; }

        public void QueueManegement()
        {
            FilaDeEntradas = new Queue("entradas");
            FilaDeAcompanhamentos = new Queue("acompanhamentos");
            FilaDeSobremesas = new Queue("sobremesas");
            FilaDeBebidas = new Queue("bebidas");
            FilaDeCarnes = new Queue("carnes");
            FilaDeMassas = new Queue("massas");
            FilaDeSaladas = new Queue("saladas");

        }
        public void QueueAdd(Item item)
        {
            switch (item.Responsable)
            {
                case AreaResponsable.Acompanhamentos:
                    FilaDeAcompanhamentos.Itens.Add(item);
                    break;
                case AreaResponsable.Entradas:
                    FilaDeEntradas.Itens.Add(item);
                    break;
                case AreaResponsable.Bebidas:
                    FilaDeBebidas.Itens.Add(item);
                    break;
                case AreaResponsable.Carnes:
                    FilaDeCarnes.Itens.Add(item);
                    break;
                case AreaResponsable.Massas:
                    FilaDeMassas.Itens.Add(item);
                    break;
                case AreaResponsable.Saladas:
                    FilaDeSaladas.Itens.Add(item);
                    break;
                case AreaResponsable.Sobremesas:
                    FilaDeSobremesas.Itens.Add(item);
                    break;
                default:
                    throw new NotImplementedException();
                    break;



            }

        }


    }
}
