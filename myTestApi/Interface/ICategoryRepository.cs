using myTestApi.Models;

namespace myTestApi.Interface
{
    public interface ICategoryRepository
    {
      public  ICollection<Category> GetCategories();
      public  Category GetCategorybyId(int Id);
        public ICollection<Pokemon> GetPokemonCategories( int categoryId);
        public bool CategoryExists(int id);

    }
}
