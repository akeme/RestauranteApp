using Microsoft.AspNetCore.Mvc;

namespace RestauranteApp.Controller
{
    public class OrderController:ControllerBase

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
                list.Add(_queueOganization.QueueOfGrill);
                list.Add(_queueOganization.QueueOfDesert);
                list.Add(_queueOganization.QueueOfDrink);
                list.Add(_queueOganization.QueueOfGarnish);
                list.Add(_queueOganization.QueueOfFries);
                list.Add(_queueOganization.QueueOfPasta);
                list.Add(_queueOganization.QueueOfSalad);


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
                    case "Salad":
                        return Ok(_queueOganization.QueueOfSalad);

                    case "Drink":
                        return Ok(_queueOganization.QueueOfDrink);

                    case "Garnish":
                        return Ok(_queueOganization.QueueOfGarnish);

                    case "Desert":
                        return Ok(_queueOganization.QueueOfDesert);
                    
                    case "Pasta":
                        return Ok(_queueOganization.QueueOfPasta);
                    
                    case "Grill":
                        return Ok(_queueOganization.QueueOfGrill);
                    
                    case "Fries":
                        return Ok(_queueOganization.QueueOfFries);         

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


                { "hamburger", new Item { Name = "Big Mac", Responsable = AreaResponsable.Grill } },
                { "fetuttine", new Item { Name = "Fetuttine", Responsable = AreaResponsable.Pasta } },
                { "guarana", new Item { Name = "Gurarana", Responsable = AreaResponsable.Drink } },
                { "cocacola", new Item { Name = "Coca-Cola", Responsable = AreaResponsable.Drink } },
                { "batata", new Item { Name = "Batata", Responsable = AreaResponsable.Garnish } },
                { "sucodelaranja", new Item { Name = "Suco de Laranja", Responsable = AreaResponsable.Drink } },
                { "nhoque", new Item { Name = "Nhoque", Responsable = AreaResponsable.Pasta } },
                { "saladacesar", new Item { Name = "Salada Cesar", Responsable = AreaResponsable.Salad } },
                { "saladatropical", new Item { Name = "Salada Tropical", Responsable = AreaResponsable.Salad } },
                { "contrafile", new Item { Name = "Contra Filé", Responsable = AreaResponsable.Grill } },
                { "nugget", new Item { Name = "Chicken Nugget", Responsable = AreaResponsable.Garnish } },
                { "brownie", new Item { Name = "Tortinha", Responsable = AreaResponsable.Desert } },
                { "sorvete", new Item { Name = "Mc Flury", Responsable = AreaResponsable.Desert } },
                { "pudim", new Item { Name = "Mc Shake", Responsable = AreaResponsable.Desert } }
            };


        }

    }
}

