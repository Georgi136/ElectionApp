using BackEnd.Data.DTO;
using BackEnd.Data.Models;

namespace BackEnd.Services
{
    public interface IMemberService
    {
        public Task<Member> AddMember(Member member);
        public Member ConvertToModelMember(AddMemberRequest addMemberRequest);
        public MemberDTO ConvertToDTOMember(Member member);
        public Task<IEnumerable<MemberDTO>>GetAllMembers();
        public Task<MemberDTO>GetMember(int id);
    }
}
