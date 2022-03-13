using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Commom.Interfaces
{
    public interface IToroDbContext
    {
        DbSet<User> Users { get; }
        DbSet<UserPosition> UserPositions { get; }
        DbSet<Position> Positions { get; }
        DbSet<UserPositionAggregate> UserPositionsAggragate { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
