using ASMembershipSystem.API.Models;
using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASMembershipSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public ActionResult<List<MemberDto>> GetAllMembers()
        {
            var members = _memberService.GetAllMembers().Select(m =>
                new MemberDto
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName
                }
            ).ToList();

            return Ok(members);
        }


        [HttpGet("{id}")]
        public ActionResult<MemberDetailDto> GetMember(int id)
        {
            var member = _memberService.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            var memberModel = new MemberDetailDto
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Sports = member.MemberSports.Select(ms => new SportDto
                {
                    Id = ms.SportId,
                    Name = ms.Sport.Name
                }).ToList()
            };

            return Ok(memberModel);
        }

        [HttpPost]
        public ActionResult<Member> PostMember(MemberDetailDto memberDetailDto)
        {
            var member = new Member
            {
                FirstName = memberDetailDto.FirstName,
                LastName = memberDetailDto.LastName,
                MemberSports = memberDetailDto.Sports.Select( s => new MemberSport 
                { 
                    SportId = s.Id
                }).ToList()
            };

            _memberService.AddMember(member);

            var memberDto = new MemberDto()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName =member.LastName
            };

            return CreatedAtAction("GetMember", new { id = member.Id }, memberDto);
        }

        [HttpPut("{id}")]
        public ActionResult PutMember(int id, MemberDetailDto memberDetailDto)
        {
            if (id != memberDetailDto.Id)
            {
                return BadRequest();
            }

            var _member = _memberService.GetMemberById(id);
            if (_member == null)
            {
                return NotFound();
            }

            var member = new Member
            {
                Id = memberDetailDto.Id,
                FirstName = memberDetailDto.FirstName,
                LastName = memberDetailDto.LastName,
                MemberSports = memberDetailDto.Sports.Select(s => new MemberSport
                {
                    SportId = s.Id
                }).ToList()
            };

            _memberService.UpdateMember(member);

            return NoContent();
        }
    }
}