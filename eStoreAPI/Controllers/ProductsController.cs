using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Model;
using BusinessObject.ModelsDTO;
using AutoMapper;
using Repositories;
using DataAccess;

namespace apiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
          if (_repository.GetProducts() == null)
          {
              return NotFound();
          }
            var listProduct = _repository.GetProducts();
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(listProduct);
            return Ok(productDTOs);
        }

        // GET: api/Products/5
        [HttpGet("id{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
          if (_repository.FindProductById(id) == null)
          {
              return NotFound();
          }
            var product = _repository.FindProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }
        // GET: api/Products/key
        [HttpGet("key{key}")]
        public async Task<ActionResult<ProductDTO>> GetProductByKey(string key)
        {
            if (_repository.FindProductByKey(key) == null)
            {
                return NotFound();
            }
            var products = _repository.FindProductByKey(key);

            if (products == null)
            {
                return NotFound();
            }
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDTOs);
        }

        [HttpGet("price")]
        public IActionResult SearchByPrice(decimal? minPrice, decimal? maxPrice)
        {
            var products = _repository.FindProductByPrice(minPrice, maxPrice);
            if (products == null || !products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDTO productDTO)
        {
            var checkproduct = _repository.FindProductById(id);
            if (checkproduct == null)
            {
                return NotFound();
            }
            var product = _mapper.Map<Product>(productDTO);
            product.ProductId = id;
            _repository.UpdateProduct(product);
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _repository.CreateProduct(product);
            productDTO.ProductId = product.ProductId;
            return Ok(productDTO);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _repository.FindProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(id);
            return NoContent();
        }
        [HttpGet("realeal")]
        public async Task<ActionResult<IEnumerable<Product>>> GetRealProducts()
        {
            if (_repository.GetProducts() == null)
            {
                return NotFound();
            }
            var listProduct = _repository.GetProducts();
            return Ok(listProduct);
        }
    }
}
