using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Versoes.Core.Domain.AutoMapper;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.Services;
using Versoes.Entities;

namespace Versoes.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLogger(this IServiceCollection services) =>
            services.AddSingleton(Log.Logger);

        public static void ConfigurePostgresContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["postgresConnection:connectionString"];
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<RepositoryContext>(o => o.UseNpgsql(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services) =>
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISetorSerive, SetorSerive>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICryptention, CipherCryptention>();
        }

        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ViewModelToCommand));
            services.AddAutoMapper(typeof(CommandToModel));
            services.AddAutoMapper(typeof(ModelToViewModel));
        }
    }
}
