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
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Auth>>> Get()
        {
            return Ok(await _context.usuarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Auth>> Get(int id)
        {
            var user = await _context.usuarios.FindAsync(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<Auth>>> AddUser(Auth user)
        {
            _context.usuarios.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.usuarios.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Auth>> UpdateUser(Auth request)
        {
            var dbUser = await _context.usuarios.FindAsync(request.Id);
            if (dbUser == null)
            {
                return BadRequest("User not found");
            }
            dbUser.Name = request.Name;
            dbUser.Email = request.Email;
            dbUser.Password = request.Password;
            dbUser.CodigoRh = request.CodigoRh;
            dbUser.Status = request.Status;
            dbUser.Cpf = request.Cpf;

            await _context.SaveChangesAsync();

            return Ok(await _context.usuarios.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var dbUser = await _context.usuarios.FindAsync(id);
            if (dbUser == null)
            {
                return BadRequest("User not found");
            }
            _context.usuarios.Remove(dbUser);
            await _context.SaveChangesAsync();


            return Ok(await _context.usuarios.ToListAsync());
        }
    }
}
