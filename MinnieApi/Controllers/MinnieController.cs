using Microsoft.AspNetCore.Mvc;

namespace MinnieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MinnieController : ControllerBase
{
    [HttpGet]
    public Minnie Get()
    {
        return new Minnie
        {
            Name = "Minnie"
        };
    }
}

public record Minnie
{
    public string Name { get; init; }
}