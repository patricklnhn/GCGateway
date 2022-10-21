using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options =>
//{
//options.SwaggerDoc("v1", new OpenApiInfo
//{
//    Version = "v1",
//    Title = "Kartverket address search APIs",
//    Description="Kartverket gateway API."//,
//    //TermsOfService = new Uri("https://example.com/terms")//,
//    //Contact = new OpenApiContact
//    //{
//    //    Name = "Example Contact",
//    //    Url = new Uri("")
//    //},
//    //License = new OpenApiLicense
//    //{
//    //    Name = "Example License",
//    //    Url = new Uri("")
//    //}
//});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x.AllowAnyHeader()
        .AllowAnyHeader()
        .WithOrigins("https://localhost:44312","http://localhost:8080",  "http://localhost:3000", "http://legacy.flow.test.nhn.no/", "https://legacy.flow.test.nhn.no/"));
//}
//app.UseWelcomePage();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
