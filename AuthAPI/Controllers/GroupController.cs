using Microsoft.AspNetCore.Mvc;
using AuthAPI.Models;
using AuthAPI.Models.Entities;
using AuthAPI.Repositories;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository repos;
        public GroupController(IGroupRepository _repos)
        {
            repos = _repos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> Read(Guid id)
        {
            var group = repos.Read(id);
            if (group == null)
            {
                return BadRequest("Nenhum grupo encontrado");
            }
            return Ok(group);
        }

        [HttpPost("create")]
        public async Task<ActionResult<List<Group>>> Create(PostCreateGroup group)
        {
            if(repos.Create(group))
            {
                return Ok("Grupo criado");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<Group>> Update(PutUpdateGroup group)
        {
            if (repos.Update(group))
            {
                return Ok("Grupo alterado");
            }
            else
            {
                return BadRequest("Nenhum grupo encontrado");
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<List<Group>>> Delete(DeleteGroup group)
        {
            if (repos.Delete(group))
            {
                return Ok("Grupo deletado.");
            }
            return BadRequest("Nenhum grupo encontrado");
        }
    }
}
