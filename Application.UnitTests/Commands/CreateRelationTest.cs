using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rangen.Application.Commands.Relations.CreateRelation;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Commands
{
    public class CreateRelationTest : CommandTestBase
    {
        [Test]

        public async Task Handle_GivenValidRequest_ShouldWorkAndAddRelationToBothOccurrencesRelationLists()
        {
            // Arrange
            var sut = new CreateRelationCommand.Handler(_context);

            var occurrence1Id = 1;
            var occurrence2Id = 2;
            var relationTypeId = 3;


            var occ1 = await _context.GenericOccurrences.SingleAsync(x => x.Id == occurrence1Id);
            var occ2 = await _context.GenericOccurrences.SingleAsync(x => x.Id == occurrence2Id);
            var relType = await _context.RelationTypes.SingleAsync(x => x.Id == relationTypeId);



            // Act
            var resultId = await sut.Handle
                (
                new CreateRelationCommand("Test Relation", occurrence1Id, true, occurrence2Id, true, relationTypeId),
            CancellationToken.None
            );



            // Assert
            var actual = await _context.Relations.FirstOrDefaultAsync(x => x.Id == resultId);

            actual.Should().NotBeNull();
            actual.RelationType.Should().Be(relType);
            actual.Occurrence1.Should().Be(occ1);
            actual.Occurrence2.Should().Be(occ2);

            actual.Occurrence1.Relations.Should().Contain(x => x.Id == resultId);
            actual.Occurrence2.Relations.Should().Contain(x => x.Id == resultId);
        }


    }
}
