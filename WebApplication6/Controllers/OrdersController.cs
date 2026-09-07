using Microsoft.AspNetCore.Mvc;
using OrderApp.Models;

namespace OrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> _orders = new()
        {
            new Order { Id = 1, Title = "Ноутбук", Description = "Ігровий ноутбук", Price = 1500, Quantity = 1 },
            new Order { Id = 2, Title = "Мишка", Description = "Бездротова мишка", Price = 25, Quantity = 2 }
        };
        private static int _nextId = 3;

        // GET: /api/orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return Ok(_orders);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Order> GetById(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound(new { message = "Замовлення не знайдено" });
            return Ok(order);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Order>> SearchByTitle([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return BadRequest(new { message = "Параметр пошуку title є обов'язковим" });

            var results = _orders.Where(o => o.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(results);
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order newOrder)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            newOrder.Id = _nextId++;
            _orders.Add(newOrder);

            return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
        }

    }
}
    