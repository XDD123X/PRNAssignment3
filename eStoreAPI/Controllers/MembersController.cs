using AutoMapper;
using BusinessObject.Model;
using BusinessObject.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;

namespace apiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IMapper _mapper;

        public MembersController(IApplicationUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetMembers()
        {
            if (_repository.GetApplicationUser() == null)
            {
                return NotFound();
            }
            var listMember = _repository.GetApplicationUser();
            //var MemberDTOs = _mapper.Map<IEnumerable<MemberDTO>>(listMember);
            return Ok(listMember);
        }

        // GET: api/Members/5
        [HttpGet("id{id}")]
        public async Task<ActionResult<MemberDTO>> GetMemberById(string id)
        {
            if (_repository.FindMemberById(id) == null)
            {
                return NotFound();
            }
            var Member = _repository.FindMemberById(id);

            if (Member == null)
            {
                return NotFound();
            }
            var MemberDTO = _mapper.Map<MemberDTO>(Member);
            return Ok(MemberDTO);
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(string id, MemberDTO MemberDTO)
        {
            var checkMember = _repository.FindMemberById(id);
            if (checkMember == null)
            {
                return NotFound();
            }
            var Member = _mapper.Map<ApplicationUser>(MemberDTO);
            Member.Id = id;
            _repository.UpdateMember(Member);
            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostMember(Register MemberDTO)
        {
            var Member = _mapper.Map<ApplicationUser>(MemberDTO);
            _repository.CreateMember(Member);
            return Ok(MemberDTO);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var Member = _repository.FindMemberById(id);
            if (Member == null)
            {
                return NotFound();
            }

            _repository.DeleteMember(id);

            return NoContent();
        }
        [HttpPost("login")]
        public async Task<ActionResult<MemberDTO>> Login([FromBody] LoginModel loginDTO)
        {
            var member = _repository.FindMemberByEmail(loginDTO.Email);

            if (member == null || member.PasswordHash != loginDTO.Password)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(member);
        }

    }
}
