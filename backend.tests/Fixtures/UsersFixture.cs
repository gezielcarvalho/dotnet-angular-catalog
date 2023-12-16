using Backend.Models;

namespace backend.tests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers()
        {
            return new List<User>()
            {
                new()
                {
                    Id = 1,
                    Name = "John",
                    Email = "john@doe.com"
                },
                new()
                {
                    Id = 2,
                    Name = "Jane",
                    Email = "jane@doe.com"
                },
                new()
                {
                    Id = 3,
                    Name = "Jack",
                    Email = "jack@doe.com"
                }
            };
        }

        internal static User GetTestUser(int userId)
        {
            return new User()
            {
                Id = userId,
                Name = "John: " + userId,
                Email = "john" + userId + "@doe.com"
            };
        }
    }
}
