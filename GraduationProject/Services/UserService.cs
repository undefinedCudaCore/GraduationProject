using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace GraduationProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository accountRepository, IConfiguration configuration)
        {
            _userRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users;
        }

        public void Register(string username, string password, string role)
        {

            if (String.IsNullOrEmpty(role) || role.Trim() != "TheEnd")
            {
                role = "User";
            }

            if (role.Trim() == "TheEnd")
            {
                role = _configuration.GetValue<string>("AdminGuid");
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            User account = new User
            {
                UserId = Guid.NewGuid(),
                Username = username,
                Password = passwordHash,
                Salt = passwordSalt,
                Role = role
            };

            _userRepository.Add(account);
        }

        public async void UserToRemoveAsync(Guid id)
        {
            _userRepository.RemoveUserAsync(id);
        }

        public bool Login(string username, string password, out string role)
        {
            var acc = _userRepository.Get(username);
            role = acc.Role;

            if (acc == null)
            {
                return false;
            }

            if (VerifyPasswordHash(password, acc.Password, acc.Salt))
            {
                return true;
            }

            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hash.SequenceEqual(passwordHash);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
