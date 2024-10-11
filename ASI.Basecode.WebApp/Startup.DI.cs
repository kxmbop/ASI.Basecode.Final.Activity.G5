using ASI.Basecode.Data;
using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Repositories;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.Services.Services;
using ASI.Basecode.WebApp.Authentication;
using ASI.Basecode.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ASI.Basecode.WebApp
{
    // Other services configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configures the other services.
        /// </summary>
        private void ConfigureOtherServices()
        {
            // Framework
            this._services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            this._services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Common
            this._services.AddScoped<TokenProvider>();
            this._services.TryAddSingleton<TokenProviderOptionsFactory>();
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            this._services.TryAddSingleton<TokenValidationParametersFactory>();
            this._services.AddScoped<IUserService, UserService>();
            this._services.AddScoped<ITicketService, TicketService>();
            this._services.AddScoped<IResponseService>(provider =>
            {
                var responseRepository = provider.GetService<IResponseRepository>();
                return new ResponseService((ResponseRepository)responseRepository);
            });
            this._services.AddScoped<IRoleService, RoleService>();
            this._services.AddScoped<IUserAccessService, UserAccessService>();

            // Repositories
            this._services.AddScoped<IUserRepository, UserRepository>();
            this._services.AddScoped<IRoleRepository, RoleRepository>();
            this._services.AddScoped<IUserAccessRepository, UserAccessRepository>();
            this._services.AddScoped<ITicketRepository>(provider =>
            {
                var unitOfWork = provider.GetService<IUnitOfWork>();
                var dbContext = provider.GetService<AsiBasecodeDBContext>();
                return new TicketRepository(dbContext, (UnitOfWork)unitOfWork);
            });
            this._services.AddScoped<IResponseRepository>(provider =>
            {
                var unitOfWork = provider.GetService<IUnitOfWork>();
                var dbContext = provider.GetService<AsiBasecodeDBContext>();
                return new ResponseRepository(dbContext, (UnitOfWork)unitOfWork);
            });


            // Manager Class
            this._services.AddScoped<SignInManager>();

            this._services.AddHttpClient();

            //Database
            this._services.AddDbContext<AsiBasecodeDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
