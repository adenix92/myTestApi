using myTestApi.Datas;
using myTestApi.Interface;
using myTestApi.Models;

namespace myTestApi.Repository
{
    public class PokemenRepository : IPokemen
    {
        private readonly DataDbContexts _dbContexts;
        public PokemenRepository(DataDbContexts _contexts)
        {
            _dbContexts = _contexts;
        }

        public ICollection<Pokemon> GetPokemens()
        {
            return _dbContexts.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
