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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetails()
        {
            if (_repository.GetOrderDetails() == null)
            {
                return NotFound();
            }
            var listOrderDetail = _repository.GetOrderDetails();
            var OrderDetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(listOrderDetail);
            return Ok(OrderDetailDTOs);
        }
        [HttpGet("oid{oid}")]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetailsByOrderId(int oid)
        {
            if (_repository.GetOrderDetails() == null)
            {
                return NotFound();
            }
            var listOrderDetail = _repository.GetOrderDetailsByOrderId(oid);
            var OrderDetailDTOs = _mapper.Map<IEnumerable<OrderDetailDTO>>(listOrderDetail);
            return Ok(OrderDetailDTOs);
        }

        // GET: api/OrderDetails/5
        [HttpGet("id")]
        public async Task<ActionResult<OrderDetailDTO>> GetOrderDetailById(int oid, int pid)
        {
            if (_repository.FindOrderDetailById(oid, pid) == null)
            {
                return NotFound();
            }
            var OrderDetail = _repository.FindOrderDetailById(oid, pid);

            if (OrderDetail == null)
            {
                return NotFound();
            }
            var OrderDetailDTO = _mapper.Map<OrderDetailDTO>(OrderDetail);
            return Ok(OrderDetailDTO);
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit")]
        public async Task<IActionResult> PutOrderDetail(int oid,int pid, OrderDetailDTO OrderDetailDTO)
        {
            var checkOrderDetail = _repository.FindOrderDetailById(oid, pid);
            if (checkOrderDetail == null)
            {
                return NotFound();
            }
            var OrderDetail = _mapper.Map<OrderDetail>(OrderDetailDTO);
            OrderDetail.OrderId = oid;
            OrderDetail.ProductId = pid;
            _repository.UpdateOrderDetail(OrderDetail);
            return NoContent();
        }

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetailDTO OrderDetailDTO)
        {
            var OrderDetail = _mapper.Map<OrderDetail>(OrderDetailDTO);
            //OrderDetail.UnitPrice = (decimal)OrderDetail.Product.UnitPrice * OrderDetail.Quantity;
            _repository.CreateOrderDetail(OrderDetail);
            return Ok(OrderDetailDTO);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteOrderDetail(int oid, int pid)
        {
            var OrderDetail = _repository.FindOrderDetailById(oid, pid);
            if (OrderDetail == null)
            {
                return NotFound();
            }

            _repository.DeleteOrderDetail(oid, pid);

            return NoContent();
        }
    }
}
