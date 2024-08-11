using Tryphon.Application.Features;
using Tryphon.Domain.Infra;
using Tryphon.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProcessoHandler, ProcessoHandler>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddPersistence();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();