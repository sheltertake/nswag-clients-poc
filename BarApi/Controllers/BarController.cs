using Microsoft.AspNetCore.Mvc;

namespace BarApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BarController : ControllerBase
{
    [HttpGet]
    public Bar Get([FromQuery]string who)
    {
        return new Bar
        {
            Name = "Bar"
        };
    }
}

public record Bar
{
    public string Name { get; init; }
}