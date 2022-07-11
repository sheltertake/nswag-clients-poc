var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddHttpClient(nameof(Proxies.BarClient), httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7081");
});
builder.Services.AddHttpClient(nameof(Proxies.MinnieClient), httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7031");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
