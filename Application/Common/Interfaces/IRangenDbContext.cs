using Microsoft.EntityFrameworkCore;
using Rangen.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.Common.Interfaces
{
    public interface IRangenDbContext
    {

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryType> CategoryTypes { get; set; }

        public DbSet<GenericOccurrence> GenericOccurrences { get; set; }

        public DbSet<SpecificOccurrence> SpecificOccurrences { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<RelationType> RelationTypes { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
