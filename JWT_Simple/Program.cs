using Jwt_Service.MiddleWare;
using JWT_Simple.DbConfig;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigDataBase(configuration);
builder.Services.ConfigAuthen(configuration);
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Manager", p => p.RequireRole("ManagerGroup", "Administrator", "Superman"));
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
app.UseCors(options => options
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)
); ;
app.UseMiddleware<JwtMiddleWare>();
app.MapControllers();

app.Run();