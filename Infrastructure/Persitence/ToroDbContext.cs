using Application.Commom.Interfaces;
using Domain.Commom;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persitence
{
    public class ToroDbContext : DbContext, IToroDbContext
    {
        private readonly IDomainEventService _domainEventService;

        public ToroDbContext(
            DbContextOptions<ToroDbContext> options,
            IDomainEventService domainEventService) : base(options)
        {
            _domainEventService = domainEventService;
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<UserPosition> UserPositions => Set<UserPosition>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<UserPositionAggregate> UserPositionsAggragate => Set<UserPositionAggregate>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
