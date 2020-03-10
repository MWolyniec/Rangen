using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rangen.Application.Commands.GenericOccurrences.CreateGenericOccurrence;
using Rangen.Application.Commands.Relations.CreateRelation;
using Rangen.Application.Commands.SpecificOccurrences.CreateSpecificOccurrence;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Commands
{
    public class CreateTests : CommandTestBase
    {

        [Test]

        public async Task CreateGenericOccurrenceHandle_GivenValidRequestWithoutAnyRelations_ShouldCreateGenericOccurrenceWithAllPropertiesCorrectlyMapped()
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

        [Test]

        public async Task CreateSpecificOccurrenceHandle_GivenValidRequestWithoutAnyRelations_ShouldCreateSpecificOccurrenceWithAllPropertiesCorrectlyMapped()
        {
            var handler = new CreateSpecificOccurrenceCommand.Handler(_context);


            var name = "Test Occurrence - Mapping Properties";
            var desc = "Test Description - Mapping Properties";
            var relativeAge = 10F;
            var relativeSize = 30F;
            var addDataName = "Test Data 2";
            var val1Name = "Test Value 2";
            var val1 = 20;
            byte dryout = 33;


            var occurrenceTypes = await _context.GenericOccurrences.Take(1).ToArrayAsync();
            var occTypeId = occurrenceTypes[0].Id;

            var occurrenceType = new GenericOccurrenceLookupDto() { Id = occTypeId };

            var addData = new AdditionalDataObject(addDataName) { Value1Name = val1Name, Value1 = val1 };


            var command = new CreateSpecificOccurrenceCommand(name)
            {
                Description = desc,
                RelativeAge = relativeAge,
                RelativeSize = relativeSize,
                DryoutFactor = dryout,
                OccurrenceType = occurrenceType,
                AdditionalData = new List<AdditionalDataObject>() { addData }

            };

            var newOccurrenceId = await handler.Handle(command, CancellationToken.None);

            var actual = await _context.SpecificOccurrences.Include(x => x.AdditionalData).FirstOrDefaultAsync(x => x.Id == newOccurrenceId);

            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
            actual.Description.Should().Be(desc);
            actual.RelativeAge.Should().Be(relativeAge);
            actual.RelativeSize.Should().Be(relativeSize);
            actual.DryoutFactor.Should().Be(dryout);
            actual.AdditionalData.Should().NotBeNullOrEmpty().And.BeEquivalentTo(command.AdditionalData);
            actual.OccurrenceType.Should().NotBeNull().And.BeSameAs(occurrenceTypes[0]);

        }

        [Test]

        public async Task CreateRelationHandle_GivenValidRequest_ShouldWorkAndAddRelationToBothOccurrencesRelationLists()
        {
            // Arrange
            var handler = new CreateRelationCommand.Handler(_context);

            var occurrence1Id = 1;
            var occurrence2Id = 2;
            var relationTypeId = 3;


            var occ1 = await _context.GenericOccurrences.SingleAsync(x => x.Id == occurrence1Id);
            var occ2 = await _context.GenericOccurrences.SingleAsync(x => x.Id == occurrence2Id);
            var relType = await _context.RelationTypes.SingleAsync(x => x.Id == relationTypeId);



            // Act
            var resultId = await handler.Handle
                (
                new CreateRelationCommand("Test Relation", occurrence1Id, true, occurrence2Id, true, relationTypeId),
            CancellationToken.None
            );



            // Assert
            var actual = await _context.Relations.Include(d => d.Occurrence1).Include(o => o.Occurrence2).FirstOrDefaultAsync(x => x.Id == resultId);

            actual.Should().NotBeNull();
            actual.RelationType.Should().Be(relType);
            actual.Occurrence1Id.Should().Be(occ1.Id);
            actual.Occurrence2Id.Should().Be(occ2.Id);

            actual.Occurrence1.RelationsAsOccurrence1.Should().Contain(x => x.Id == resultId);
            actual.Occurrence2.RelationsAsOccurrence2.Should().Contain(x => x.Id == resultId);
        }

    }
}
