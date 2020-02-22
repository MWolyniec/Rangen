using Rangen.Persistence;
using System;

namespace Rangen.Application.UnitTests
{
    public class CommandTestBase : IDisposable
    {
        protected readonly RangenDbContext _context;

        public CommandTestBase()
        {
            _context = RangenContextFactory.Create();
        }

        public void Dispose()
        {
            RangenContextFactory.Destroy(_context);
        }
    }
}
