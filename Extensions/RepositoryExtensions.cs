using evenement.Repository;
using evenement.Repository.IRepository;

namespace evenement.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services){
            services.AddScoped<IRoleRepoitory,RoleRepository>();
            services.AddScoped<IEvenementRepository, EvenementRepository>();
            services.AddScoped<ITypeRepository,TypeRepository>();
            services.AddScoped<IMessageRepository,MessageRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}