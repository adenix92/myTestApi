using myTestApi.Models;

namespace myTestApi.dto
{
    public class Ownerdto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }
        public Country Countrys { get; set; }
    }
}
