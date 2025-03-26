namespace GoalTrackingAPI.Services
{
    using System.Security.Cryptography;
    using System.Text;
    using GoalTrackingAPI.Database;
    using GoalTrackingAPI.Database.Models;
    using GoalTrackingAPI.Dtos.Identity;

    public class IdentityService
    {
        private MongoDatabase _database;
        public IdentityService(MongoDatabase database)
        {
            _database = database;
        }

        public async Task<bool> RegisterUser(RegistrationDto registration)
        {
            //validate if there is already an user with the same username
            var existingUser = await _database.Users.GetByUsernameAsync(registration.Username);
            if (existingUser != null)
            {
                return false;
            }

            //if unique, create user
            await _database.Users.CreateAsync(new User
            {
                Username = registration.Username,
                Password = ComputeHash(registration.Password),
            });
            return true;
        }

        public async Task<bool> ValidatePasswordHash(string password, string hash) {
            return ComputeHash(password).Equals(hash);
        }

        public string ComputeHash(string password)
        {
            HashAlgorithm sha = SHA256.Create();
            Byte[] input = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = sha.ComputeHash(input);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
