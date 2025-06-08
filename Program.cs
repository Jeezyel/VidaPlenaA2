using HOSPISIM.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os necess�rios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona DbContext
builder.Services.AddDbContext<VidaPlenaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona Autoriza��o (IMPORTANTE!)
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware padr�o
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Se estiver usando autentica��o:
app.UseAuthentication(); // S� se estiver usando JWT ou algo similar
app.UseAuthorization();  // Necess�rio com [Authorize]

app.MapControllers();
app.Run();
