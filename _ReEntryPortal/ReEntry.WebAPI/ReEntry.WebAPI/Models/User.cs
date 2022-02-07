namespace ReEntry.WebAPI
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = ""; // имя пользователя
        public int Age { get; set; } // возраст пользователя
    }

}
