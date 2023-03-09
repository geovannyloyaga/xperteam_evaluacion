using xperteam.ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Inject Denpendency
builder.Services.InjectDependencies(builder.Configuration);
#endregion

#region Enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicity", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicity");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
