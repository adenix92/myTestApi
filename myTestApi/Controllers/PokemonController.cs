using Microsoft.AspNetCore.Mvc;
using myTestApi.Datas;
using myTestApi.Interface;
using myTestApi.Models;

namespace myTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemen __pokemen;
        //private readonly IMapper _mapper;
        public PokemonController(IPokemen _pokemen)
        {
            this.__pokemen = _pokemen;
        }


        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult getPokemen()
        {
            var p = __pokemen.GetPokemens();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(p);
            
           // return View();
        }
    }
}
