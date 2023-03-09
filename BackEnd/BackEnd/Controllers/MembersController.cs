
using AutoMapper;
using BackEnd.Data.DTO;
using BackEnd.Repositories;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MembersController : Controller
    {
        private readonly IMemberRepository memberRepository;
        private readonly IMapper mapper;
        private readonly IMemberService memberService;


        public MembersController(IMemberService memberService, IMemberRepository memberRepository, IMapper mapper)
        {
            this.memberRepository = memberRepository;
            this.memberService = memberService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            
            var membersDTO = await memberService.GetAllMembers();
            if(membersDTO == null)
                return NotFound();
            return Ok(membersDTO);
        }
        [HttpGet]
        [Route("{id}")]
        [ActionName("GetMemberAsync")]
        public async Task<IActionResult> GetMemberAsync(int id)
        { 
            var memberDTO = await memberService.GetMember(id);
                if(memberDTO == null)
                    return NotFound(id);
            return Ok(memberDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddMemberAsync(AddMemberRequest addMemberRequest)
        {
            var member = memberService.ConvertToModelMember(addMemberRequest);

            member = await memberService.AddMember(member);

            var memberDTO = memberService.ConvertToDTOMember(member); 

            return CreatedAtAction(nameof(GetMemberAsync), new { id = memberDTO.Id }, memberDTO);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleateMemberAsync(int id)
        {
            var member = await memberRepository.DeleteAsync(id);
            if ( member == null)
                return NotFound();
            var memberDTO = memberService.ConvertToDTOMember(member);
            return Ok(memberDTO);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMemberAsync([FromRoute] int id,[FromBody] Data.DTO.AddMemberRequest addMemberRequest)
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

            member = await memberRepository.UpdateAsync(id, member);

            if (member == null)
                return NotFound();
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

            return Ok(memberDTO);
        }       
    }
}
