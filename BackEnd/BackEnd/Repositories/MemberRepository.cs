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

        public async Task<Member> DeleteAsync(int id)
        {
            var member = await izboriDbContext.Members.FirstOrDefaultAsync(x => x.Id == id);
            if (member == null)
            {
                return null;
            }

            izboriDbContext.Members.Remove(member);
            await izboriDbContext.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateAsync(int id, Member member)
        {
            var existingMember = await izboriDbContext.Members.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMember == null)
            {
                return null;
            }

            existingMember.Id = member.Id;
            existingMember.FirstName = member.FirstName;
            existingMember.SecondName = member.SecondName;
            existingMember.ThirdName = member.ThirdName;
            existingMember.Education = member.Education;
            existingMember.Egn = member.Egn;
            existingMember.PhoneNumber = member.PhoneNumber;

            await izboriDbContext.SaveChangesAsync();
            return existingMember;
        }
    }
}
