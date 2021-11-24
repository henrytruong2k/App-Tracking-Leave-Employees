using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using server.Helpers;
using server.Interfaces;
using server.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace server.Responsitories
{
    public class EmployeeRespository : IEmployeeRespository
    {
        private readonly MyDbContext _context;
        private readonly AppSettings _appSettings;

        public EmployeeRespository(MyDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<List<Employee>> GetListAsync()
        {
            return await _context.Employees.Include(x => x.Approver)
                .OrderByDescending(x=>x.Id).ToListAsync();
        }

        public async Task<Employee> InsertAsync(Employee emp)
        {
            emp.CreatedAt = DateTime.Now;
            emp.UpdatedAt = DateTime.Now;
            await _context.AddAsync(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
        public async Task<Employee> UpdateAsync(Employee emp)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == emp.Id);
            if (result == null) return null;

            //  
            
            
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Employee> GetApprover(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.ApproverId == id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees
                .Include(x => x.Approver)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> Authenticate(string email, string password)
        {
            var user = await _context.Employees.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user == null) return null;

            var token = generateToken(user);
            user.AccessToken = token;
            return user;
        }

        private string generateToken(Employee emp)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, emp.FullName),
                    new Claim(ClaimTypes.Role, emp.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
    }
}
