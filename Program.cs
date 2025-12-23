var builder = WebApplication.CreateBuilder(args);

// --------------------
// הוספת שירותים
// --------------------

// מוסיפים Controllers
builder.Services.AddControllers();

// Swagger (לבדיקות)
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// הוספת CORS עבור Angular
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4201") // Angular URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --------------------
// בניית האפליקציה
// --------------------
var app = builder.Build();

// --------------------
// Middleware
// --------------------
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
   // app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

// חשוב: UseCors צריך להיות לפני MapControllers
app.UseCors();

app.UseAuthorization();

// --------------------
// מיפוי Controllers
// --------------------
app.MapControllers();

app.Run();
