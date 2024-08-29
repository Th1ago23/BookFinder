namespace Bookfinder.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        protected string Password { get; set; }

    }
}
