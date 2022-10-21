using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Junta APIs",
        Description = "Junta gateway API. For JuntaContacts parameter iType use enum, email=0, ids=1, name=2"//,
        //TermsOfService = new Uri("https://example.com/terms")//,
        //Contact = new OpenApiContact
        //{
        //    Name = "Example Contact",
        //    Url = new Uri("")
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("")
        //}
    });
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();


//app.Logger.LogInformation("Starting Application");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();



//Gir mulighet til å kalle fra localhost og fra andre sites spesifisert i WithOrigins
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyHeader()
    .WithOrigins("https://localhost","http://localhost", "http://localhost:53315", "https://localhost:53315", "https://localhost:44312", "http://localhost:8080", "http://localhost:3000", "http://legacy.flow.test.nhn.no/", "https://legacy.flow.test.nhn.no/")
); //
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
