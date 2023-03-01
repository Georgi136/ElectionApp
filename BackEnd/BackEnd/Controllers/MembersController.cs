
using AutoMapper;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MembersController : Controller
    {
        private readonly IMemberRepository memberRepository;
        private readonly IMapper mapper;

        public MembersController(IMemberRepository memberRepository, IMapper mapper)
        {
            this.memberRepository = memberRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await memberRepository.GetAllAsync();
            if (members == null)
                return NotFound();
            var regionsDTO = mapper.Map<List<Data.DTO.Member>>(members);
            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("{id}")]
        [ActionName("GetMemberAsync")]
        public async Task<IActionResult> GetMemberAsync(int id)
        { 
            var member = await memberRepository.GetAsync(id);
            var memberDTO = mapper.Map<Data.DTO.Member>(member);
            return Ok(memberDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddMemberAsync(Data.DTO.AddMemberRequest addMemberRequest)
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
            member = await memberRepository.AddAsync(member);

            var memberDTO = new Data.DTO.Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                SecondName = member.SecondName,
                ThirdName = member.ThirdName,
                Egn = member.Egn,
                Education = member.Education,
                PhoneNumber = member.PhoneNumber
            };
            return CreatedAtAction(nameof(GetMemberAsync), new { id = memberDTO.Id }, memberDTO);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleateMemberAsync(int id)
        {
            var member = await memberRepository.DeleteAsync(id);
            if ( member == null)
                return NotFound();
            var memberDTO = new Data.DTO.Member()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                SecondName = member.SecondName,
                ThirdName = member.ThirdName,
                Egn = member.Egn,
                Education = member.Education,
                PhoneNumber = member.PhoneNumber
            };
            return Ok(memberDTO);
        }
    }
}
