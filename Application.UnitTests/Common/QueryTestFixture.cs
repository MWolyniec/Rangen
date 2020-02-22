using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Persistence;
using System;

namespace Rangen.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public RangenDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = RangenContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            RangenContextFactory.Destroy(Context);
        }
    }

    /*  [CollectionDefinition("QueryCollection")]
      public class QueryCollection : ICollectionFixture<QueryTestFixture> { }*/
}
