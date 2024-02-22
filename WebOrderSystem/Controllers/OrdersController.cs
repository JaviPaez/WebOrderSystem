using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOrderSystem.Context;

namespace WebOrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("LastOrdersByMember")]
        public IActionResult GetLastOrdersByMember()
        {
            var lastOrdersQuery = _context.Orders
                .Include(o => o.Member)
                .Include(o => o.Product)
                .GroupBy(o => o.MemberId)
                .Select(g => g.OrderByDescending(o => o.DateOrder).FirstOrDefault());

            var lastOrders = lastOrdersQuery.ToList();

            var result = lastOrders.Select(o => new
            {
                MemberName = o.Member.Name,
                ProductName = o.Product.Name,
                OrderDate = o.DateOrder
            }).OrderBy(o => o.OrderDate).ToList();

            return Ok(result);
        }
    }
}
