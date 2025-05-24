using Microsoft.EntityFrameworkCore;
using TeamTrain.Infrastructure.Contexts;
using TeamTrain.Infrastructure.Multitenancy;

namespace TeamTrain.WebApi.Middleware;

public class TenantResolutionMiddleware(RequestDelegate next, ILogger<TenantResolutionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider, MainDbContext mainDbContext)
    {
        var host = context.Request.Host.Host;
        var subdomain = host.Split('.').FirstOrDefault();

        if (string.IsNullOrWhiteSpace(subdomain) || subdomain == "www" || subdomain == "app")
        {
            logger.LogInformation("Request to global scope (no tenant)");
            await next(context);
            return;
        }

        var tenant = await mainDbContext.Tenants
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Subdomain == subdomain);

        if (tenant == null)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Tenant not found.");
            return;
        }

        tenantProvider.SetTenant(new TenantDto
        {
            Name = tenant.Subdomain,
            ConnectionString = tenant.ConnectionString
        });

        logger.LogInformation("Resolved tenant: {Tenant}", tenant.Subdomain);

        await next(context);
    }
}