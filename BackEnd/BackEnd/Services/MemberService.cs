using AutoMapper;
using BackEnd.Data.DTO;
using BackEnd.Data.Models;
using BackEnd.Repositories;

namespace BackEnd.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;
        private readonly IMapper mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            this.memberRepository = memberRepository;
            this.mapper = mapper;
        }
        public async Task<Member> AddMember(Member member)
        {
           return await memberRepository.AddAsync(member);
        }

        public MemberDTO ConvertToDTOMember(Member member)
        {
            var memberDTO = new Data.DTO.MemberDTO()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                SecondName = member.SecondName,
                ThirdName = member.ThirdName,
                Egn = member.Egn,
                Education = member.Education,
                PhoneNumber = member.PhoneNumber
            };
            return  memberDTO;
        }

        public Member ConvertToModelMember(AddMemberRequest addMemberRequest)
        {
            var member = new Data.Models.Member()
            {
                FirstName = addMemberRequest.FirstName,
                SecondName = addMemberRequest.SecondName,
                ThirdName = addMemberRequest.ThirdName,
                Egn = addMemberRequest.Egn,
                Education = addMemberRequest.Education,
                PhoneNumber = addMemberRequest.PhoneNumber
            };
            return member;
        }

        public async Task<Member> DeleteMember(int id)
        {
            var member = await memberRepository.DeleteAsync(id);
            if (member == null)
                return null;
            return member;
        }

        public async Task<IEnumerable<MemberDTO>> GetAllMembers()
        {
            var members = await memberRepository.GetAllAsync();
            if (members == null)
                return null;
            var membersDTO = mapper.Map<List<MemberDTO>>(members);
            
            return membersDTO;
        }

        public async Task<MemberDTO> GetMember(int id)
        {
            var member = await memberRepository.GetAsync(id);
            if (member == null)
                return null;
            var memberDTO = mapper.Map<Data.DTO.MemberDTO>(member);
            
            return memberDTO;
        }

        public async Task<Member> UpdateMember(Member member, int id)
        {
            var updatedMember = await memberRepository.UpdateAsync(id, member);
            if (updatedMember == null)
                return null;
            return updatedMember;
        }
    }
}
