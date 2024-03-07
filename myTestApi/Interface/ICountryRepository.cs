using myTestApi.Models;

namespace myTestApi.Interface
{
    public interface ICountryRepository
    {   
        bool checkCountry(int Id);
        IEnumerable<Country> GetCountryAll();
        Country GetCountrybyId(int id);
        Country CountryByOwner (int ownerId);
        ICollection<Owners> getOwnerFromCountry(int countryId);
    }
}
