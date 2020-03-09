using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rangen.Application.Commands.GenericOccurrences.CreateGenericOccurrence;
using Rangen.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Commands
{
    public class CreateOccurrenceTest : CommandTestBase
    {

        [Test]

        public async Task Handle_GivenValidRequestWithoutAnyRelations_ShouldCreateGenericOccurrenceWithAllPropertiesCorrectlyMapped()
        {
            var handler = new CreateGenericOccurrenceCommand.Handler(_context);


            var name = "Test Occurrence - Mapping Properties";
            var desc = "Test Description - Mapping Properties";
            var chance = 20F;
            var addDataName = "Test Data 1";
            var val1Name = "Test Value 1";
            var val1 = 10;
            var addData = new AdditionalDataObject(addDataName) { Value1Name = val1Name, Value1 = val1 };


            var command = new CreateGenericOccurrenceCommand(name)
            {
                Description = desc,
                GeneralChanceToOccur = chance,
                AdditionalData = new List<AdditionalDataObject>() { addData }

            };

            var newOccurrenceId = await handler.Handle(command, CancellationToken.None);

            var actual = await _context.GenericOccurrences.Include(x => x.AdditionalData).FirstOrDefaultAsync(x => x.Id == newOccurrenceId);

            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
            actual.Description.Should().Be(desc);
            actual.GeneralChanceToOccur.Should().Be(chance);
            actual.AdditionalData.Should().NotBeNullOrEmpty().And.BeEquivalentTo(command.AdditionalData);
        }

    }
}
