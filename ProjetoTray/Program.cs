using Application.Service;
using Core.IRepositories;
using Core.IService;
using Core.Repositories;
using Infrastruture.Repositories.Data;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configuração do DbContext
        builder.Services.AddDbContext<trayprojeto45DbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                             ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

        // Configuração do CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("PermitirTodasOrigens",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
        });

        // Registro de serviços e controllers
        builder.Services.AddControllers();
        builder.Services.AddScoped<IRepositoryCompra, RepositoryCompra>();
        builder.Services.AddScoped<ICompraService, CompraService>();
        builder.Services.AddScoped<IRepositoryPessoa, RepositoryPessoa>();
        builder.Services.AddScoped<IPessoaService, PessoaService>();
        builder.Services.AddScoped<IAuthService, AuthService>(); // Adicionando AuthService

        // Configuração do Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Chamada para SeedData
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<trayprojeto45DbContext>();
            SeedData.Initialize(context);
        }

        // Middleware de tratamento de erros
        app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { error = "Ocorreu um erro no servidor." });
            }
        });

        app.UseCors("PermitirTodasOrigens");

        // Configuração do Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
            c.RoutePrefix = string.Empty;
        });

        app.MapControllers();
        app.Run();
    }
}