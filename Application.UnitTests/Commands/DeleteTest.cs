using FluentAssertions;
using NUnit.Framework;
using Rangen.Application.Commands.Categories.DeleteCategory;
using Rangen.Application.Commands.Common;
using Rangen.Application.Commands.GenericOccurrences.DeleteGenericOccurrence;
using Rangen.Application.Commands.Items.Delete;
using Rangen.Application.Commands.Relations.DeleteRelation;
using Rangen.Application.Commands.RelationTypes.Delete;
using Rangen.Application.Commands.SpecificOccurrences.DeleteSpecificOccurrence;
using Rangen.Application.UnitTests.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Commands
{
    public class DeleteTests : QueryTestBase
    {
        private readonly DeleteSpecificOccurrenceCommandHandler deleteSpecificOccurrenceCommandHandler;
        private readonly DeleteGenericOccurrenceCommandHandler deleteGenericOccurrenceCommandHandler;
        private readonly DeleteRelationCommandHandler deleteRelationCommandHandler;
        private readonly DeleteRelationTypeCommandHandler deleteRelationTypeCommandHandler;
        private readonly DeleteCategoryCommandHandler deleteCategoryCommandHandler;
        private readonly DeleteCategoryTypeCommandHandler deleteCategoryTypeCommandHandler;


        public DeleteTests() : base()
        {
            deleteSpecificOccurrenceCommandHandler = new DeleteSpecificOccurrenceCommandHandler(_context);
            deleteGenericOccurrenceCommandHandler = new DeleteGenericOccurrenceCommandHandler(_context);
            deleteRelationCommandHandler = new DeleteRelationCommandHandler(_context);
            deleteRelationTypeCommandHandler = new DeleteRelationTypeCommandHandler(_context);
            deleteCategoryCommandHandler = new DeleteCategoryCommandHandler(_context);
            deleteCategoryTypeCommandHandler = new DeleteCategoryTypeCommandHandler(_context);
        }


        [Test]
        public async Task SpecificOccurrenceHandle_GivenValidId_DeletesSpecificOccurrence()
        {
            var validId = _context.SpecificOccurrences.Take(1).ToArray()[0].Id;

            var command = new DeleteItemCommand { Id = validId };

            await deleteSpecificOccurrenceCommandHandler.Handle(command, CancellationToken.None);

            var specificOccurrence = await _context.SpecificOccurrences.FindAsync(validId);

            specificOccurrence.Should().BeNull();
        }

        [Test]
        public async Task GenericOccurrenceHandle_GivenValidId_DeletesGenericOccurrence()
        {
            var validId = _context.GenericOccurrences.Take(1).ToArray()[0].Id;

            var command = new DeleteItemCommand { Id = validId };

            await deleteGenericOccurrenceCommandHandler.Handle(command, CancellationToken.None);

            var genericOccurrence = await _context.GenericOccurrences.FindAsync(validId);

            genericOccurrence.Should().BeNull();
        }

        [Test]
        public async Task CategoryHandle_GivenValidId_DeletesCategory()
        {
            var validId = _context.Categories.Take(1).ToArray()[0].Id;

            var command = new DeleteItemCommand { Id = validId };

            await deleteCategoryCommandHandler.Handle(command, CancellationToken.None);

            var category = await _context.Categories.FindAsync(validId);

            category.Should().BeNull();
        }
        [Test]
        public async Task CategoryTypeHandle_GivenValidId_DeletesCategoryType()
        {
            var validId = _context.CategoryTypes.Take(1).ToArray()[0].Id;

            var command = new DeleteItemCommand { Id = validId };

            await deleteCategoryTypeCommandHandler.Handle(command, CancellationToken.None);

            var categoryType = await _context.CategoryTypes.FindAsync(validId);

            categoryType.Should().BeNull();
        }
        [Test]
        public async Task RelationTypeHandle_GivenValidId_DeletesRelationType()
        {
            var validId = _context.RelationTypes.Take(1).ToArray()[0].Id;

            var command = new DeleteItemCommand { Id = validId };

            await deleteRelationTypeCommandHandler.Handle(command, CancellationToken.None);

            var relationType = await _context.RelationTypes.FindAsync(validId);

            relationType.Should().BeNull();
        }

        [Test]
        public async Task RelationHandle_GivenValidId_DeletesRelationAndCleanOccurrenceReferencesToIt()
        {

            var relation = _context.Relations.Take(1).ToArray()[0];
            var validId = relation.Id;

            var occ1 = relation.Occurrence1;
            var occ2 = relation.Occurrence2;

            var command = new DeleteItemCommand { Id = validId };

            await deleteRelationCommandHandler.Handle(command, CancellationToken.None);

            relation = await _context.Relations.FindAsync(validId);

            relation.Should().BeNull();
            occ1.Should().NotBeNull();
            occ1.RelationsAsOccurrence1.Should().NotContain(relation);
            occ1.RelationsAsOccurrence2.Should().NotContain(relation);

            occ2.Should().NotBeNull();
            occ2.RelationsAsOccurrence1.Should().NotContain(relation);
            occ2.RelationsAsOccurrence2.Should().NotContain(relation);
        }

    }
}
