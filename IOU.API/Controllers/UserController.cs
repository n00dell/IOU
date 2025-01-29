using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IOU.API.Data;
using IOU.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace IOU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOUContext _context;

        public UserController(IOUContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(string.IsNullOrEmpty(user.Email)|| string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Email and Password are required");
            }
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return Conflict("Email already exists");
            }
            user.Password = HashPassword(user.Password);

            user.Id = Guid.NewGuid().ToString();
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.PhoneNumber,
                user.CreatedDate,
                user.IsActive,
                user.UserType
            });
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery]string email,[FromQuery] string password)
        {
            Console.WriteLine($"Email:{email}, Password: {password}");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(user==null)
            {
                Console.WriteLine("User not found");
                return NotFound("Invalid email or password");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            Console.WriteLine($"Password valid: {isPasswordValid}");

            if (!isPasswordValid)
            {
                return NotFound("Invalid email or password");
            }
            return Ok(new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.PhoneNumber,
                user.CreatedDate,
                user.IsActive,
                user.UserType
            });
        }

        
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
