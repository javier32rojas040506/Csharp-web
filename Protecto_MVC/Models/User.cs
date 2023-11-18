namespace Protecto_MVC.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FSName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } = "N/A";
        public DateTime DOBirthday { get; set; }
        public int Age { get; set; }
    }
}