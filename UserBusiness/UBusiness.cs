using UserDomain;

namespace UserBusiness
{
    public class UBusiness
    {
        private UserDB.UserDB userDatabase = UserDB.UserDB.GetInstance();
        public User getUser()
        {
            User user = new User();

            user.UserName = "JoganC07";
            user.Password = "qwerty123";
            user.FSName = "Johan Sebastian";
            user.LastName = "Cediel Malaver";
            user.Email = "johancediel07ABC@gmail.com";
            user.Phone = "3002885679";
            user.DOBirthay = DateTime.Parse("2000/09/16");
            user.Age = get_age(user.DOBirthay);

            userDatabase.AddUser(user);

            return user;
        }

        public List<User> getUsers()
        {
            return userDatabase.GetAllUsers();
        }

        private int get_age(DateTime dob)
        { 
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }

        public void addUser(User user)
        {
            userDatabase.AddUser(user);
        }

        public bool deleteUserByUsername(String userName){
            return userDatabase.deleteUserByUsername(userName);
        }

    }
}