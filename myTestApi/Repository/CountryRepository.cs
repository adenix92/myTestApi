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

        public bool deleteCountry(Country countryId)
        {
            _Contexts.Remove(countryId);
            return saveCountry();
        }

        public bool saveCountry()
        {
            var add = _Contexts.SaveChanges();
            return add>0?true:false;
        }

        public bool CreateNewCountry(Country country)
        {
            var addup = _Contexts.Add(country);
            return saveCountry();

        }
       public bool updateCountry(Country country)
        {
            _Contexts.Update(country);
            return saveCountry();
        }
    }
}
