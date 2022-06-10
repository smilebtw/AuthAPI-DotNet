using AuthAPI.Models;
using AuthAPI.Models.Entities;
using AuthAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repos;
        public UserController(IUserRepository _repos)
        {
            repos = _repos;
        }
        [HttpPost("register")]
        public async Task<ActionResult<List<User>>> Register(PostRegisterUser user)
        {
            if (repos.Register(user))
            {
                return Ok("Usuário registrado.");
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<List<User>>> Login(PostLoginUser user)
        {
            if (repos.Login(user))
            {
                return Ok("Usuário logado.");
            }
            return BadRequest();
            // Resta implementar o Token
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<List<User>>> Delete(DeleteLoginUser user)
        {
            if (repos.Delete(user))
            {
                return Ok("Usuário deletado.");
            }
            return BadRequest("Nenhum usuário encontrado");
        }

        [HttpPut("update")]
        public async Task<ActionResult<List<User>>> Update(PutLoginUser user)
        {
            if (repos.Update(user))
            {
                return Ok("Usuário atualizado");
            }
            return BadRequest("Nenhum usuário encontrado");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Read(Guid id)
        {
            var user = repos.Read(id);
            if (user == null)
            {
                return BadRequest("Nenhum usuário encontrado");
            }
            return Ok(user);
        }
    }
}
