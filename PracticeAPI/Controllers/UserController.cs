using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Entity;
using PracticeAPI.Model;
using PracticeAPI.Repository;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;

        public UserController(IMapper mapper, IUserRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var list = await _repo.GetUserEntities();
            if(list == null) return BadRequest();

            return Ok(list);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var user = _mapper.Map<UserEntity>(userLogin);
            var token = await _repo.Login(user);
            if (string.IsNullOrEmpty(token)) return Unauthorized();
            return Ok(token);
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUp userSignUp)
        {
            var user = _mapper.Map<UserEntity>(userSignUp);
            var userEntity = await _repo.SignUp(user);
            if(userEntity == null) return Unauthorized();
            else return Ok(userEntity);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var isDelete = await _repo.Delete(id);
            if (isDelete) return Ok();
            return BadRequest();
        }
    }
}
