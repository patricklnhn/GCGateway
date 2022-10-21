var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//Gir mulighet til å kalle fra localhost og fra andre sites spesifisert i WithOrigins
    app.UseCors(x => x.AllowAnyHeader()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:44312", "http://localhost:8080", "http://localhost:3000", "http://legacy.flow.test.nhn.no/", "https://legacy.flow.test.nhn.no/")
    );
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
