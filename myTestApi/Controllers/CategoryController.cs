using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myTestApi.dto;
using myTestApi.Interface;
using myTestApi.Models;

namespace myTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository  _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper) { 
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Category>))]
        public IActionResult getCategories()
        {
            var categories = _mapper.Map<List<Categorydto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid) 
            return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200,Type =typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategorybyId(int Id)
        {
            if(!_categoryRepository.CategoryExists(Id))
                return NotFound();

            var cId = _mapper.Map<Categorydto>(_categoryRepository.GetCategorybyId(Id));
            
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cId);

        }

        [HttpGet("Pokemon/{categoryId}")]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonCategories(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();
            //
            var pc = _mapper.Map<List<Pokemendto>>(_categoryRepository.GetPokemonCategories(categoryId));
            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pc);

        }
        
    }
}
