using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities.App;
using TeamTrain.Domain.Interfaces.Repositories;
using TeamTrain.Infrastructure.Contexts;

namespace TeamTrain.Infrastructure.Persistence.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly TenantDbContext _context;
    private readonly DbSet<Membership> _memberships;

    public MembershipRepository(TenantDbContext context)
    {
        _context = context;
        _memberships = _context.Memberships;
    }
}