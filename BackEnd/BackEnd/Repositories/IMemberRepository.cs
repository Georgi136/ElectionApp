using BackEnd.Data.Models;

namespace BackEnd.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member> GetAsync(int id);
        Task<Member> AddAsync(Member member);
        Task<Member> DeleteAsync(int id);

    }
}
