using AutoMapper;
using myTestApi.dto;
using myTestApi.Models;
using System.Runtime.InteropServices;
namespace myTestApi.Mappingprofiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, Pokemendto>();
            CreateMap<Category, Categorydto>();
            CreateMap<Country, Countrydto>();

        }
    }
}
