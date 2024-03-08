using Microsoft.AspNetCore.Mvc;
using myTestApi.Datas;
using myTestApi.Interface;
using myTestApi.Models;
using System.Linq;

namespace myTestApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataDbContexts _Contexts;
        public CountryRepository(DataDbContexts _dataDbContexts)
        {
            _Contexts = _dataDbContexts;
            
        }

       
        public bool checkCountry(int Id)
        {
            return _Contexts.Countries.Any(c => c.Id == Id);
        }

        public Country CountryByOwner(int ownerId)
        {
            return _Contexts.Owners.Where(c => c.Id == ownerId).Select(c => c.Countrys).FirstOrDefault();
        }

        public IEnumerable<Country> GetCountryAll()
        {
            return _Contexts.Countries.ToList();
        }

        public Country GetCountrybyId(int id)
        {
            return _Contexts.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Owners> getOwnerFromCountry(int countryId)
        {
            return _Contexts.Owners.Where(c=>c.Countrys.Id==countryId).ToList();
        }
    }
}
