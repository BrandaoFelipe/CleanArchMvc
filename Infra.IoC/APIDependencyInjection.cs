using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Account;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Identity;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infra.IoC
{
    public static class APIDependencyInjection
    {
        public static IServiceCollection AddInfraStructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(AppDbContext)
                            .Assembly.FullName)
                        )
            );
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

            services.AddScoped<IAuthenticate, AuthenticateService>();
            
            return services;

        }
    }
}
