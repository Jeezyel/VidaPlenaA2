using HOSPISIM.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços necessários
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona DbContext
builder.Services.AddDbContext<VidaPlenaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona Autorização (IMPORTANTE!)
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware padrão
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Se estiver usando autenticação:
app.UseAuthentication(); // Só se estiver usando JWT ou algo similar
app.UseAuthorization();  // Necessário com [Authorize]

app.MapControllers();
app.Run();
