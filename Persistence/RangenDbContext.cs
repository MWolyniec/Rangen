using Microsoft.EntityFrameworkCore;
using Rangen.Application.Common.Interfaces;
using Rangen.Common;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Persistence
{
    public class RangenDbContext : DbContext, IRangenDbContext
    {


        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<GenericOccurrence> GenericOccurrences { get; set; }
        public DbSet<SpecificOccurrence> SpecificOccurrences { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<RelationType> RelationTypes { get; set; }

        public RangenDbContext(DbContextOptions<RangenDbContext> options) : base(options)
        {

        }

        public RangenDbContext(DbContextOptions<RangenDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<Occurrence>().HasMany(d => d.AdditionalData);

            modelBuilder.Entity<Relation>()
           .HasOne(pt => pt.Occurrence1)
           .WithMany(d => d.RelationsAsOccurrence1)
           .HasForeignKey(pt => pt.Occurrence1Id)
           .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Relation>()
                .HasOne(x => x.Occurrence2)
                .WithMany(d => d.RelationsAsOccurrence2)
                .HasForeignKey(pt => pt.Occurrence2Id)
                .OnDelete(DeleteBehavior.Restrict);






            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RangenDbContext).Assembly);
        }
    }
}
