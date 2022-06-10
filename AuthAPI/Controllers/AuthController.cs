using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<Auth> users = new List<Auth>
        {
            new Auth
            {
                Id = 1,
                Name = "Gabriel",
                Email = "test@gmail.com",
                Password = "test123",
                CodigoRh = 41234,
                Cpf = "46950944870",
                Status = 1
            },
            new Auth
            {
                Id = 2,
                Name = "Paulo",
                Email = "test2@gmail.com",
                Password = "test1234",
                CodigoRh = 12345,
                Cpf = "12345678910",
                Status = 0
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<Auth>>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Auth>> Get(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<Auth>>> AddUser(Auth user)
        {   
            users.Add(user);
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<Auth>> UpdateUser(Auth request)
        {
            var user = users.Find(x => x.Id == request.Id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.CodigoRh = request.CodigoRh;
            user.Status = request.Status;
            user.Cpf = request.Cpf;

            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            users.Remove(user);
            return Ok(users);
        }
    }
}
