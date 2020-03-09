using AutoMapper;
using Rangen.Application.Common.Mappings;
using Rangen.Persistence;
using System;

namespace Rangen.Application.UnitTests.Common
{
    public class QueryTestBase : IDisposable
    {
        protected RangenDbContext _context { get; private set; }
        protected IMapper _mapper { get; private set; }

        public QueryTestBase()
        {
            _context = RangenContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            RangenContextFactory.Destroy(_context);
        }
    }

    /*  [CollectionDefinition("QueryCollection")]
      public class QueryCollection : ICollectionFixture<QueryTestFixture> { }*/
}
