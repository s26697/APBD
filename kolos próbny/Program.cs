

using kolos_próbny.Repository;
using kolos_próbny.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// tutaj scoped interfaces
builder.Services.AddScoped<IPerscriptionRepository, PerscriptionRepository>();
builder.Services.AddScoped<IPerscriptionService, PerscriptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

