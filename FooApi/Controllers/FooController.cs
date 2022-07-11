using Microsoft.AspNetCore.Mvc;
using Proxies;

namespace FooApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FooController : ControllerBase
{
    private readonly BarClient _barClient;
    private readonly MinnieClient _minnieClient;

    public FooController(IHttpClientFactory httpClientFactory)
    {
        var barClient = httpClientFactory.CreateClient(nameof(BarClient));
        _barClient = new Proxies.BarClient(barClient.BaseAddress.ToString(), barClient);

        var minnieClient = httpClientFactory.CreateClient(nameof(MinnieClient));
        _minnieClient = new Proxies.MinnieClient(minnieClient.BaseAddress.ToString(), minnieClient);
    }

    [HttpGet]
    public async Task<Friends> GetAsync()
    {
        var bar = await _barClient.BarAsync(who: "pippo");
        var minnie = await _minnieClient.MinnieAsync();
        return new Friends
        {
           Names = new List<string> { bar.Name, minnie.Name }
        };
        //return new Foo
        //{
        //    Name = "Foo"
        //};
    }
}
public record Friends
{
    public IEnumerable<string> Names { get; set; }
}
public record Foo
{
    public string Name { get; set; }
}