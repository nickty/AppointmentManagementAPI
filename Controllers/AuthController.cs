[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register(string username, string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User { Username = username, PasswordHash = passwordHash };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(new { Message = "User registered successfully" });
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return Unauthorized();

        var token = _tokenService.GenerateToken(username);
        return Ok(new { Token = token });
    }
}
