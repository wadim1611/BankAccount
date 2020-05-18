using BankAccount.Api.AppServices;
using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Core.Domain.Services;
using BankAccount.Core.Domain.Services.Interfaces;
using BankAccount.Core.Persistance.Contexts;
using BankAccount.Core.Persistance.Repositories;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using ExchangeRatesClientEcb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Api.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IExchangeRateService, ExchangeRateService>();
            services.AddHttpClient<IExchangeRateClient, ExchangeRateClientEcb>();

            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddScoped<ICurrencyManager, CurrencyManager>();
            services.AddScoped<ICurrencyService, CurrencyService>();

            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
