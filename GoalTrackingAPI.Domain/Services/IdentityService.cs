namespace GoalTrackingAPI.Domain.Services
{
    using System.Security.Cryptography;
    using System.Text;
    using GoalTrackingAPI.Domain.Models.Identity;
    using GoalTrackingAPI.Domain.Models.Users;

    public class IdentityService
    {
        private Database.MongoDatabase _database;
        public IdentityService(Database.MongoDatabase database)
        {
            _database = database;
        }

        public async Task<User> RegisterUser(UserRegistrationData data)
        {
            //validate if there is already an user with the same username
            var existingUser = await _database.Users.GetByUsernameAsync(data.Username);
            if (existingUser != null)
            {
                return null;
            }

            //if unique, create user
            var newUser = new User(data.Firstname, data.Lastname, data.Email, ComputeHash(data.Password), data.Username);
            await _database.Users.CreateAsync(newUser.ToEntity());

            return newUser;
        }

        // TEMP: HashGen and Validation should be moved somewhere else
        public async Task<bool> ValidatePasswordHash(string password, string hash)
        {
            return ComputeHash(password).Equals(hash);
        }

        public static string ComputeHash(string password)
        {
            HashAlgorithm sha = SHA256.Create();
            Byte[] input = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = sha.ComputeHash(input);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
