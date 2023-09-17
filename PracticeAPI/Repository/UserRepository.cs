using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PracticeAPI.Entity;
using PracticeAPI.Enum;
using PracticeAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PracticeAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;
        private readonly IConfiguration _config;

        public UserRepository(MyDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<bool> Delete(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if(user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<UserEntity>> GetUserEntities()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<string> Login(UserEntity user)
        {
            var result = await _context.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
            if(result == null)
            {
                return string.Empty;
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, AppEnum.Role.user.ToString()),
                new Claim("Username",user.UserName),
                new Claim("Password",user.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]));
            var token = new JwtSecurityToken
            (
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authKey,SecurityAlgorithms.Aes128CbcHmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserEntity> SignUp(UserEntity user)
        {
            var userRegister = await _context.Users.FindAsync(user.UserName);
            if (userRegister != null) return null;
            else
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }           
        }

        private string GenerateToken(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, AppEnum.Role.admin.ToString()),
                new Claim("Username", user.UserName),
                new Claim("Password", user.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]));
            var token = new JwtSecurityToken
            (
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.Aes256Encryption)
            );
            return new JwtSecurityTokenHandler().WriteToken (token);
        }

    }
}
