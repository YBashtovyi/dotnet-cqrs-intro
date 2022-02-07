using ReEntry.WebAPI.Models;

namespace ReEntry.WebAPI.Init
{
    public class Persons
    {
        public static Person Kowalski()
        {
            return new Person
            (
                "Jan",
                "Kowalski",
                "1111111116"
            );
        }
    }
}