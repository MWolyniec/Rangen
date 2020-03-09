using FluentAssertions;
using NUnit.Framework;
using Rangen.Application.Queries.GetCategoriesList;
using Rangen.Application.Queries.GetCategoryTypesList;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Application.Queries.GetRelations;
using Rangen.Application.Queries.GetRelationTypes;
using Rangen.Application.Queries.GetSpecificOccurrences;
using Rangen.Application.UnitTests.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rangen.Application.UnitTests.Queries
{
    public class GetListsTest : QueryTestBase
    {
        [Test]
        public async Task GetAllSpecificOccurrencesList_ShouldReturn_NotEmpty()
        {
            var sut = new GetSpecificOccurrencesListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetSpecificOccurrencesListQuery(), CancellationToken.None);

            var itemCount = _context.SpecificOccurrences.Count();


            result.Items.Should().NotBeEmpty();
            result.Items.Count.Should().Be(itemCount);
            result.Items.FirstOrDefault(x => x.Id != 0).Should().NotBeNull();

        }
        [Test]
        public async Task GetAllGenericOccurrencesList_ShouldReturn_NotEmpty()
        {
            var sut = new GetGenericOccurrencesListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetGenericOccurrencesListQuery(), CancellationToken.None);


            var itemCount = _context.GenericOccurrences.Count();

            result.Items.Should().NotBeEmpty();
            result.Items.Count.Should().Be(itemCount);
            result.Items.FirstOrDefault(x => x.Id != 0).Should().NotBeNull();
        }

        [Test]
        public async Task GetAllCategoriesList_ShouldReturn_NotEmpty()
        {
            var sut = new GetCategoriesListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            var itemCount = _context.Categories.Count();


            result.Items.Should().NotBeEmpty();
            result.Items.Count.Should().Be(itemCount);
            result.Items.FirstOrDefault(x => x.Id != 0).Should().NotBeNull();
        }


        [Test]
        public async Task GetAllCategoryTypesList_ShouldReturn_Empty()
        {
            var sut = new GetCategoryTypesListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCategoryTypesListQuery(), CancellationToken.None);

            var itemCount = _context.CategoryTypes.Count();


            result.Items.Should().BeEmpty();
            result.Items.Count.Should().Be(itemCount);
            result.Items.FirstOrDefault(x => x.Id != 0).Should().BeNull();
        }

        [Test]
        public async Task GetAllRelationsList_ShouldReturn_Empty()
        {
            var sut = new GetRelationsListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetRelationsListQuery(), CancellationToken.None);

            var itemCount = _context.Relations.Count();


            result.Items.Should().BeEmpty();
            result.Items.Count.Should().Be(itemCount);
            result.Items.FirstOrDefault(x => x.Id != 0).Should().BeNull();
        }

        [Test]
        public async Task GetAllRelationTypesList_ShouldReturn_NotEmpty()
        {
            var sut = new GetRelationTypesListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetRelationTypesListQuery(), CancellationToken.None);

            var itemCount = _context.RelationTypes.Count();


            result.Items.Should().NotBeEmpty();
            result.Items.Count.Should().Be(itemCount);
            result.Items.FirstOrDefault(x => x.Id != 0).Should().NotBeNull();
        }

    }
}
