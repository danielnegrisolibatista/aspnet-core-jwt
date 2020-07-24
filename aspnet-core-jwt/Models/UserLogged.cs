namespace aspnet_core_jwt.Models
{
    public class UserLogged
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }
    }
}
