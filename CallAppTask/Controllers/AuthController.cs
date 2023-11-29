using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenGenerator _tokenGenerator;

    public AuthController(TokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpGet("generate-token")]
    public IActionResult GenerateToken()
    {
        var token = _tokenGenerator.GenerateToken();
        return Ok(new { token });
    }
}