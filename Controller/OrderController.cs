using Microsoft.AspNetCore.Mvc;

namespace RestauranteApp.Controller
{
    public class OrderController

    {
       
        private Dictionary<string, Item> _catalogo;

        private IQueueOrganization _queueOganization;

        public void OrdemController(IQueueOrganization queueOganization)
        {
            _queueOganization = queueOganization;
            _catalogo = InitCatalogo();
        }

        [HttpPost("itens/")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                var itens = order.ItemsName.Split(",");
                foreach (var item in itens)
                {
                    if (_catalogo.TryGetValue(item.Trim(), out var it))
                    {
                        _queueOganization.QueueAdd(it);
                    }

                }

                return Ok();

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("queues/")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = new List<Queue>();
                list.Add(_queueOganization.FilaDeCarnes);
                list.Add(_queueOganization.FilaDeSobremesas);
                list.Add(_queueOganization.FilaDeBebidas);
                list.Add(_queueOganization.FilaDeAcompanhamentos);
                list.Add(_queueOganization.FilaDeEntradas);
                list.Add(_queueOganization.FilaDeMassas);
                list.Add(_queueOganization.FilaDeSaladas);


                return Ok(list);

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("queues/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                switch (name)
                {
                    case "saladas":
                        return Ok(_queueOganization.FilaDeSaladas);

                    case "bebidas":
                        return Ok(_queueOganization.FilaDeBebidas);

                    case "acompanhamentos":
                        return Ok(_queueOganization.FilaDeAcompanhamentos);

                    case "sobremesas":
                        return Ok(_queueOganization.FilaDeSobremesas);
                    
                    case "massas":
                        return Ok(_queueOganization.FilaDeMassas);
                    
                    case "carnes":
                        return Ok(_queueOganization.FilaDeCarnes);
                    
                    case "entradas":
                        return Ok(_queueOganization.FilaDeEntradas);         

                    default:
                        return NotFound("Essa fila não existe!");
                }
                return Ok();

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private Dictionary<string, Item> InitCatalogo()
        {
            return new Dictionary<string, Item>()
            {


                { "hamburger", new Item { Name = "Big Mac", Responsable = AreaResponsable.Carnes } },
                { "fetuttine", new Item { Name = "Big Tasty", Responsable = AreaResponsable.Massas } },
                { "guarana", new Item { Name = "Gurarana", Responsable = AreaResponsable.Bebidas } },
                { "cocacola", new Item { Name = "Coca-Cola", Responsable = AreaResponsable.Bebidas } },
                { "batata", new Item { Name = "Batata", Responsable = AreaResponsable.Acompanhamentos } },
                { "sucodelaranja", new Item { Name = "Suco de Laranja", Responsable = AreaResponsable.Bebidas } },
                { "nhoque", new Item { Name = "Nhoque", Responsable = AreaResponsable.Massas } },
                { "saladacesar", new Item { Name = "Salada Cesar", Responsable = AreaResponsable.Saladas } },
                { "saladatropical", new Item { Name = "Salada Tropical", Responsable = AreaResponsable.Saladas } },
                { "contrafile", new Item { Name = "Contra Filé", Responsable = AreaResponsable.Carnes } },
                { "nugget", new Item { Name = "Chicken Nugget", Responsable = AreaResponsable.Acompanhamentos } },
                { "brownie", new Item { Name = "Tortinha", Responsable = AreaResponsable.Sobremesas } },
                { "sorvete", new Item { Name = "Mc Flury", Responsable = AreaResponsable.Sobremesas } },
                { "pudim", new Item { Name = "Mc Shake", Responsable = AreaResponsable.Sobremesas } }
            };


        }

    }
}

