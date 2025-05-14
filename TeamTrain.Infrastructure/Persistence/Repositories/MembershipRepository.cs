using Microsoft.EntityFrameworkCore;
using TeamTrain.Domain.Entities;
using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Infrastructure.Persistence.Repositories;

public class MembershipRepository : IMembershipRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Membership> _memberships;

    public MembershipRepository(ApplicationDbContext context)
    {
        _context = context;
        _memberships = _context.Memberships;
    }
}