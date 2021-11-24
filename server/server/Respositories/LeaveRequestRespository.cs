using Microsoft.EntityFrameworkCore;
using server.Interfaces;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Responsitories
{
    public class LeaveRequestRespository : ILeaveRequestRespository
    {
        private readonly MyDbContext _context;
        public LeaveRequestRespository(MyDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<LeaveRequest>> GetListAsync(int? month, int? year)
        {
            if(month != null && year != null)
            {
                return await _context.LeaveRequests.Include(x => x.CreatedBy)
                .Include(x => x.RequestedBy)
                .Where(x => x.CreatedAt.Value.Month == month && x.CreatedAt.Value.Year == year)
                .OrderByDescending(x => x.Id).ToListAsync();
            }
            return await _context.LeaveRequests.Include(x => x.CreatedBy)
                .Include(x => x.RequestedBy)
                .OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<LeaveRequest> FindById(int id)
        {
            return await _context.LeaveRequests
                .Include(x => x.CreatedBy)
                .Include(x => x.RequestedBy)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsByEmployee(int id)
        {
            var histories = await _context.LeaveRequests.Include(x => x.CreatedBy)
                .Include(x => x.RequestedBy)
                .Where(x => x.CreatedById == id)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
            if (histories == null) return null;
            return histories;
                
        }

        public async Task<LeaveRequest> Add(LeaveRequest entity)
        {
            await _context.LeaveRequests.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<LeaveRequest> UpdateAsync(LeaveRequest entity)
        {
            var result = await FindById(entity.Id);
            if (result == null) return null;
            result.UpdatedAt = DateTime.Now;
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<LeaveRequest>> Check(int id)
        {
            return await _context.LeaveRequests.Include(x => x.CreatedBy)
                .Include(x => x.RequestedBy)
                .Where(x => x.RequestedById == id)
                .ToListAsync();
        }

        
    }
}
