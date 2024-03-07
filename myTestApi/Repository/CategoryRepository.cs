using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myTestApi.Datas;
using myTestApi.Interface;
using myTestApi.Models;

namespace myTestApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataDbContexts _dbContexts;
       
        public CategoryRepository(DataDbContexts _Db) { 
        _dbContexts = _Db;
          
            }

        public bool CategoryExists(int id)
        {
            return _dbContexts.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _dbContexts.Categories.ToList();
        }

        public Category GetCategorybyId(int id)
        {
            var equery = from c in _dbContexts.Categories where c.Id == id select c;
            return equery.FirstOrDefault<Category>();
        }

        public ICollection<Pokemon> GetPokemonCategories(int categoryId)
        {
            return _dbContexts.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemons).ToList();
        }
    }
}
