using Corrupcion.Helpers;
using Corrupcion.Repository.Interfaces;
using Corrupcion.Repository.Services;
using Corrupcion.Services.Interfaces;
using Corrupcion.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<CorrupcionContext>();
builder.Services.AddScoped<InfoLogger>();
builder.Services.AddScoped<IPartidosRepository, PartidosRepository>();
builder.Services.AddScoped<IPartidosService, PartidosService>();
builder.Services.AddScoped<IGobiernosRepository, GobiernosRepository>();
builder.Services.AddScoped<IGobiernosService, GobiernosService>();
builder.Services.AddScoped<IPresidentesService, PresidentesService>();
builder.Services.AddScoped<IPresidentesRepository, PresidentesRepository>();
builder.Services.AddScoped<IEscandalosService, EscandalosService>();
builder.Services.AddScoped<IEscandalosRepository, EscandalosRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
