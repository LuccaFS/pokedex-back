using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Service.Services
{
    
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(UserRegister user)
        {
            UserDTO userExist = _userRepository.getUser(user.DsEmail);
            if(userExist != null)
            {
                throw new Exception("E-mail already in use.");
            }
            CreatePasswordHash(user.DsPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.DsPassword = Convert.ToBase64String(passwordHash);
            var newUser = _userRepository.Create(user, passwordSalt);
        }

        public bool Login(LoginModel login, out string msgErr, out string token)
        {
            msgErr = string.Empty;
            token = string.Empty;
            UserDTO user = _userRepository.getUser(login.DsEmail);
            if (user == null)
            {
                msgErr = "User not found";
                return false;
            }
            if(!VerifyPasswordHash(login.DsPassword, Convert.FromBase64String(user.DsPassword), Convert.FromBase64String(user.DsSalt)))
            {
                msgErr = "Wrong Password";
                return false;
            }

            token = CreateToken(user);

            return true;
            
        }

        #region ' Get User Authorized '
        public User getUser()
        {
            User user = new User { };
            if (_httpContextAccessor != null)
            {
                user.Id = Int32.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                user.DsName = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                user.DsRank = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return user;
            
        }
        #endregion

        private string CreateToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.DsName),
                new Claim(ClaimTypes.NameIdentifier, user.IdTrainer.ToString()),
                new Claim(ClaimTypes.Role, user.RankName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
