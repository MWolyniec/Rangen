using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using Rangen.Application.Queries.GetSpecificOccurrences;
using Rangen.Application.UnitTests.Common;
using Rangen.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Queries
{
    public class GetSpecificOccurrenceDetailsHandlerTest : QueryTestBase
    {


        [Test]
        public async Task GetSpecificOccurrenceDetailById()
        {
            var sut = new GetSpecificOccurrenceDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetSpecificOccurrenceDetailQuery { Id = 6 }, CancellationToken.None);

            result.Should().BeOfType<SpecificOccurrenceDetailVm>();
            result.Id.Should().Be(6);
        }
    }
}
