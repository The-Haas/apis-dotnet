
using api_final.Database.Models;
using api_final.DTOs;
using api_final.Services;
using api_final.Services.DTOs;
using api_final.Validators;
using FluentValidation;


namespace api_final;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddControllers().AddXmlSerializerFormatters(); // permite resposta em XML
        builder.Services.AddDbContext<ChamadosContext>();
        builder.Services.AddScoped<ResponsaveisService>();
        builder.Services.AddScoped<IValidator<ResponsavelRequestDTO>, ResponsavelValidator>();
        builder.Services.AddScoped<ClientesService>();
        builder.Services.AddScoped<IValidator<ClienteRequestDTO>, ClienteValidator>();
        builder.Services.AddScoped<TelefonesService>();
        builder.Services.AddScoped<IValidator<TelefoneRequestDTO>, TelefoneValidator>();
        builder.Services.AddScoped<EmailsService>();
        builder.Services.AddScoped<IValidator<EmailRequestDTO>, EmailValidator>();
        builder.Services.AddScoped<ChamadoService>();
        builder.Services.AddScoped<IValidator<ChamadoRequestDTO>, ChamadoValidator>();
        builder.Services.AddScoped<ChamadoCompletoService>();



        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

