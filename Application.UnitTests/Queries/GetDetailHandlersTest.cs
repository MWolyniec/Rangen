using FluentAssertions;
using NUnit.Framework;
using Rangen.Application.Common.Exceptions;
using Rangen.Application.Queries.GetCategories;
using Rangen.Application.Queries.GetCategoryTypes;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Application.Queries.GetRelations;
using Rangen.Application.Queries.GetRelationTypes;
using Rangen.Application.Queries.GetSpecificOccurrences;
using Rangen.Application.UnitTests.Common;
using Rangen.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Queries
{
    public class GetDetailHandlersTest : QueryTestBase
    {


        [Test]
        public async Task GetSpecificOccurrenceDetailsById_ShouldHave_ProperTypeIdAndFilledProperties()
        {
            var sut = new GetSpecificOccurrenceDetailQueryHandler(_context, _mapper);


            var entity = _context.SpecificOccurrences.Take(1).ToArray()[0];

            var entityId = entity.Id;

            var result = await sut.Handle(new GetSpecificOccurrenceDetailQuery { Id = entityId }, CancellationToken.None);

            result.Should().BeOfType<SpecificOccurrenceDetailVm>();
            result.Id.Should().Be(entityId);
        }

        [Test]
        public async Task GetGenericOccurrenceDetailsById_ShouldHave_ProperTypeAndId()
        {
            var sut = new GetGenericOccurrenceDetailQueryHandler(_context, _mapper);


            var entity = _context.GenericOccurrences.Take(1).ToArray()[0];

            var entityId = entity.Id;

            var result = await sut.Handle(new GetGenericOccurrenceDetailQuery { Id = entityId }, CancellationToken.None);

            result.Should().BeOfType<GenericOccurrenceDetailVm>();
            result.Id.Should().Be(entityId);
        }

        [Test]
        public async Task GetRelationDetailsById_ShouldThrow_NotFoundException()
        {
            var sut = new GetRelationDetailQueryHandler(_context, _mapper);

            var name = nameof(Relation);
            var id = 1;

            sut.Invoking(x => x.Handle(new GetRelationDetailQuery { Id = id }, CancellationToken.None))
               .Should().Throw<NotFoundException>().WithMessage($"Entity \"{name}\" ({id}) was not found.");
        }

        [Test]
        public async Task GetRelationTypeDetailsById_ShouldHave_ProperTypeAndId()
        {
            var sut = new GetRelationTypeDetailQueryHandler(_context, _mapper);


            var entity = _context.RelationTypes.Take(1).ToArray()[0];

            var entityId = entity.Id;

            var result = await sut.Handle(new GetRelationTypeDetailQuery { Id = entityId }, CancellationToken.None);

            result.Should().BeOfType<RelationTypeDetailVm>();
            result.Id.Should().Be(entityId);
        }

        [Test]
        public async Task GetCategoryDetailsById_ShouldHave_ProperTypeAndId()
        {
            var sut = new GetCategoryDetailQueryHandler(_context, _mapper);


            var entity = _context.Categories.Take(1).ToArray()[0];

            var entityId = entity.Id;

            var result = await sut.Handle(new GetCategoryDetailQuery { Id = entityId }, CancellationToken.None);

            result.Should().BeOfType<CategoryDetailVm>();
            result.Id.Should().Be(entityId);
        }

        [Test]
        public async Task GetCategoryTypeDetailsById_ShouldHave_ProperTypeAndId()
        {
            var sut = new GetCategoryTypeDetailQueryHandler(_context, _mapper);


            var name = nameof(CategoryType);
            var id = 1;

            sut.Invoking(x => x.Handle(new GetCategoryTypeDetailQuery { Id = id }, CancellationToken.None))
               .Should().Throw<NotFoundException>().WithMessage($"Entity \"{name}\" ({id}) was not found.");
        }

    }
}
