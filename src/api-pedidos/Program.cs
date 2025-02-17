using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MeuContexto>(options =>
    options.UseSqlite("Data Source=meubanco.db"));

// Adiciona serviços ao contêiner
builder.Services.AddControllers();

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPoliticaDeCors", builder =>
    {
        builder.AllowAnyOrigin() // Permite qualquer origem
               .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
               .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

// Adiciona suporte ao Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MinhaPoliticaDeCors"); // Aplica a política de CORS
app.UseAuthorization();
app.MapControllers();
app.Run();