var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --------------------
// בניית האפליקציה
// --------------------
var app = builder.Build();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
