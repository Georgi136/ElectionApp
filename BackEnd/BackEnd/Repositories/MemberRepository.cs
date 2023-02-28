using BackEnd.Data;
using BackEnd.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IzboriDbContext izboriDbContext;

        public MemberRepository(IzboriDbContext izboriDbContext)
        {
            this.izboriDbContext = izboriDbContext;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await izboriDbContext.Members.ToListAsync();
        }
        public async Task<Member> GetAsync(int id)
        {
            return await izboriDbContext.Members.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Member> AddAsync(Member member)
        { 
            member.Id = new int();
            await izboriDbContext.Members.AddAsync(member);
            await izboriDbContext.SaveChangesAsync();
            return member;
        }
    }
}
