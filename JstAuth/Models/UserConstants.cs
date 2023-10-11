namespace JstAuth.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel()
            {
                Username = "gervaldo_director",
                EmailAddress="gervaldo.dir@email.com",
                Password = "MyPass_w0rd",
                GivenName = "Gervaldo",
                Surname = "Golimar",
                Role = "Director"
            },
            new UserModel()
            {
                Username = "jorjina_professor",
                EmailAddress="joji.prof@email.com",
                Password = "The_X_v4lue",
                GivenName = "Jorjina",
                Surname = "Jeitosa",
                Role = "Professor"
            },
            new UserModel()
            {
                Username = "barth_student",
                EmailAddress="barth.stu@email.com",
                Password = "BadGrad0s_ru1es",
                GivenName = "Barth",
                Surname = "Simpson",
                Role = "Student"
            },

        };
    }
}
