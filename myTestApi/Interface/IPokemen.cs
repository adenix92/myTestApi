using myTestApi.Models;

namespace myTestApi.Interface
{
    public interface IPokemen
    {
        public ICollection<Pokemon> GetPokemens();
    }
}
