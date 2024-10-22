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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategorys()
        {
            if (_repository.GetCategories() == null)
            {
                return NotFound();
            }
            var listCategory = _repository.GetCategories();
            var CategoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(listCategory);
            return Ok(CategoryDTOs);
        }

        // GET: api/Categorys/5
        [HttpGet("id{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            if (_repository.FindCategoryById(id) == null)
            {
                return NotFound();
            }
            var Category = _repository.FindCategoryById(id);

            if (Category == null)
            {
                return NotFound();
            }
            var CategoryDTO = _mapper.Map<CategoryDTO>(Category);
            return Ok(CategoryDTO);
        }

        // PUT: api/Categorys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDTO CategoryDTO)
        {
            var checkCategory = _repository.FindCategoryById(id);
            if (checkCategory == null)
            {
                return NotFound();
            }
            var Category = _mapper.Map<Category>(CategoryDTO);
            Category.CategoryId = id;
            _repository.UpdateCategory(Category);
            return NoContent();
        }

        // POST: api/Categorys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryDTO CategoryDTO)
        {
            var Category = _mapper.Map<Category>(CategoryDTO);
            _repository.CreateCategory(Category);
            return Ok(CategoryDTO);
        }

        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Category = _repository.FindCategoryById(id);
            if (Category == null)
            {
                return NotFound();
            }

            _repository.DeleteCategory(id);

            return NoContent();
        }
    }
}
