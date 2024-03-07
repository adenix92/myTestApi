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
        [ProducesResponseType(200,Type =typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult getOwnerFromCountry(int country_Id)
        {
            if(!_IcountryRep.checkCountry(country_Id)) return NotFound();
            var get_owner_from_country = _mapper.Map<Countrydto>(_IcountryRep.getOwnerFromCountry(country_Id));
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(get_owner_from_country);
        }


    }
}
