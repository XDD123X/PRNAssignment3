using AutoMapper;
using BusinessObject.Model;
using BusinessObject.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace apiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderDetailRepository _repositoryod;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            if (_repository.GetOrders() == null)
            {
                return NotFound();
            }
            var listOrder = _repository.GetOrders();
            var OrderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(listOrder);
            return Ok(OrderDTOs);
        }
        [HttpGet("memid{memid}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByMemberId(string memid)
        {
            if (_repository.GetOrders() == null)
            {
                return NotFound();
            }
            var listOrder = _repository.GetOrdersByMemberId(memid);
            var OrderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(listOrder);
            return Ok(OrderDTOs);
        }

        // GET: api/Orders/5
        [HttpGet("id{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
        {
            if (_repository.FindOrderById(id) == null)
            {
                return NotFound();
            }
            var Order = _repository.FindOrderById(id);

            if (Order == null)
            {
                return NotFound();
            }
            var OrderDTO = _mapper.Map<OrderDTO>(Order);
            return Ok(OrderDTO);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDTO OrderDTO)
        {
            var checkOrder = _repository.FindOrderById(id);
            if (checkOrder == null)
            {
                return NotFound();
            }
            var Order = _mapper.Map<Order>(OrderDTO);
            Order.OrderId = id;
            _repository.UpdateOrder(Order);
            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO OrderDTO)
        {
            var Order = _mapper.Map<Order>(OrderDTO);
            Order.OrderDate = DateTime.Now;
            Order.OrderDetails = null;
            _repository.CreateOrder(Order);
            OrderDTO.OrderId = Order.OrderId;
            return Ok(OrderDTO);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var Order = _repository.FindOrderById(id);
            if (Order == null)
            {
                return NotFound();
            }
            _repository.DeleteOrder(id);

            return NoContent();
        }
        //[HttpGet("salesReport")]
        //public async Task<ActionResult<IEnumerable<OrderDTO>>> GetSalesReport(DateTime startDate, DateTime endDate)
        //{
        //    if (_repository.GetSalesReport(startDate, endDate) == null)
        //    {
        //        return NotFound();
        //    }
        //    var listOrder = _repository.GetSalesReport(startDate, endDate);
        //    var OrderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(listOrder).OrderBy(o => o.totalItem);
        //    return Ok(OrderDTOs);
        //}
    }
}
