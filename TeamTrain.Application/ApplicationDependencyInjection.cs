using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TeamTrain.Application.Common.Behaviours;
using TeamTrain.Application.Interfaces.Multitenancy;
using TeamTrain.Application.Interfaces.SaaS.Auth;
using TeamTrain.Application.Interfaces.Tenants.Auth;
using TeamTrain.Application.Services.Multitenancy;
using TeamTrain.Application.Services.SaaS.Auth;
using TeamTrain.Application.Services.Tenants.Auth;
using TeamTrain.Domain.Interfaces.Repositories;
using TeamTrain.Domain.Interfaces.Repositories.SaaS;
using TeamTrain.Domain.Interfaces.UnitOfWork;
using TeamTrain.Infrastructure.Multitenancy;
using TeamTrain.Infrastructure.Persistence.Repositories;
using TeamTrain.Infrastructure.Persistence.Repositories.SaaS;
using TeamTrain.Infrastructure.Persistence.UnitOfWork;

namespace TeamTrain.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();

        #region SaaS

        services.AddScoped<ITenantProvider, TenantProvider>();
        services.AddScoped<IAuthClientService, AuthClientService>();
        services.AddScoped<ITokenClientService, TokenClientService>();
        services.AddScoped<IPortalUserRepository, PortalUserRepository>();
        services.AddScoped<IRefreshTokenClientRepository, RefreshTokenClientRepository>();

        #endregion

        #region Tenant

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<ITrainingRepository, TrainingRepository>();
        services.AddScoped<IMembershipRepository, MembershipRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        #endregion

        return services;
    }
}