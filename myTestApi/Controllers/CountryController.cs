using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myTestApi.Datas;
using myTestApi.dto;
using myTestApi.Interface;
using myTestApi.Models;

namespace myTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _IcountryRep;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository _db,IMapper _im) { 
        _IcountryRep = _db;
            _mapper = _im;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountryAll()
        {
            var getall = _mapper.Map<List<Countrydto>>(_IcountryRep.GetCountryAll());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(getall);


        }

        [HttpGet("{byid}")]
        [ProducesResponseType(200,Type=typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult CountryByOwner(int byid) { 
        
            if(!_IcountryRep.checkCountry(byid)) return NotFound();
            var ownerIds = _mapper.Map<Countrydto>(_IcountryRep.CountryByOwner(byid));

            if(!ModelState.IsValid) 
            return BadRequest(ModelState);

            return Ok(ownerIds);
        
        }

        [HttpGet("byId")]
        [ProducesResponseType(200,Type=typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountrybyId(int byId)
        {
            if (!_IcountryRep.checkCountry(byId)) return NotFound();
                
            var getC = _mapper.Map<Country>(_IcountryRep.GetCountrybyId(byId));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(getC);

        }

        [HttpGet("/owners/{country_Id}")]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Owners>))]
        [ProducesResponseType(400)]
        public IActionResult getOwnerFromCountry(int country_Id)
        {
            if(!_IcountryRep.checkCountry(country_Id)) return NotFound();
            var get_owner_from_country = _mapper.Map<List<Ownerdto>>(_IcountryRep.getOwnerFromCountry(country_Id));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(get_owner_from_country);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateNewCountry([FromBody] Countrydto _countrydto)
        {
            if (_countrydto==null) return BadRequest(ModelState);
            //check the country name if it's already exist
            var newInstanceCountry = _IcountryRep.GetCountryAll().Where(x=>x.Name.ToUpper() 
            == _countrydto.Name.ToUpper()).FirstOrDefault();

            if (newInstanceCountry != null)
            {
                ModelState.AddModelError("", "The Country Name Already exist");
                return StatusCode(422, ModelState);
            }

            var addup = _mapper.Map<Country>(_countrydto);
            
            
                if(!_IcountryRep.CreateNewCountry(addup))
                    {
                    ModelState.AddModelError("", "server was unable to process the file");
                    return StatusCode(500, ModelState);
                
                    }
                
                

            
            return Ok("Account created successfully");

        }


    }
}
