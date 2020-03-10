using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rangen.Application.Commands.Categories.CreateCategory;
using Rangen.Application.Commands.CategoryTypes.Upsert;
using Rangen.Application.Commands.GenericOccurrences.CreateGenericOccurrence;
using Rangen.Application.Commands.Relations.CreateRelation;
using Rangen.Application.Commands.RelationTypes.Upsert;
using Rangen.Application.Commands.SpecificOccurrences.CreateSpecificOccurrence;
using Rangen.Application.Queries.GetCategories;
using Rangen.Application.Queries.GetCategoryTypes;
using Rangen.Application.Queries.GetGenericOccurrences;
using Rangen.Application.Queries.GetRelationTypes;
using Rangen.Domain.Common;
using Rangen.Domain.Entities;
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
        [Test]

        public async Task UpsertCategoryTypeHandle_GivenValidRequest_ShouldCreateNewEntity()
        {
            // Arrange
            var handler = new UpsertCategoryTypeCommand.Handler(_context);

            var name = "Test Relation Type";
            var desc = "Just a test rel type";

            var addDataName = "Test Data 2";
            var val1Name = "Test Value 2";
            var val1 = 20;

            var addData = new AdditionalDataObject(addDataName) { Value1Name = val1Name, Value1 = val1 };

            var categoryEntities = await _context.Categories.Take(3).ToListAsync();

            var categoryDtos = categoryEntities.Select(x => new CategoryLookupDto() { Id = x.Id }).ToList();

            var command = new UpsertCategoryTypeCommand(name)
            {
                Description = desc,
                Categories = categoryDtos,
                AdditionalData = new List<AdditionalDataObject> { addData }
            };

            // Act
            var resultId = await handler.Handle(command, CancellationToken.None);


            // Assert
            var actual = await _context.CategoryTypes.FirstOrDefaultAsync(x => x.Id == resultId);

            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
            actual.Description.Should().Be(desc);
            actual.AdditionalData.Should().Contain(addData);
        }

        [Test]

        public async Task CreateCategoryHandle_GivenValidRequest_ShouldWork()
        {
            // Arrange
            var handler = new CreateCategoryCommand.Handler(_context);

            var name = "Test Category 12";
            var desc = "Category 12 description";

            var addDataName = "Test Data 222";
            var val1Name = "Test Value 222";
            var val1 = 222;

            var addData = new AdditionalDataObject(addDataName) { Value1Name = val1Name, Value1 = val1 };

            var categoryType = new CategoryType("Test Category Type 122");

            _context.CategoryTypes.Add(categoryType);
            await _context.SaveChangesAsync();

            var catTypeId = categoryType.Id;

            var catTypeDto = new CategoryTypeLookupDto() { Id = catTypeId };

            var genOccs = _context.GenericOccurrences.Take(2).ToList();
            var genOccsDtos = genOccs.Select(x => new GenericOccurrenceLookupDto { Id = x.Id }).ToList();


            var command = new CreateCategoryCommand(name)
            {
                Description = desc,
                AdditionalData = new List<AdditionalDataObject> { addData },
                CategoryType = catTypeDto,
                GenericOccurrences = genOccsDtos
            };

            // Act
            var resultId = await handler.Handle(command, CancellationToken.None);



            // Assert
            var actual = await _context.Categories.FirstOrDefaultAsync(x => x.Id == resultId);

            actual.Should().NotBeNull();
            actual.AdditionalData.Should().Contain(addData);
            actual.Name.Should().Be(name);
            actual.Description.Should().Be(desc);
            actual.CategoryType.Should().BeSameAs(categoryType);
            actual.GenericOccurrences.Should().Contain(genOccs);
        }

        [Test]

        public async Task UpsertRelationTypeHandle_GivenValidRequest_ShouldCreateNewEntity()
        {
            // Arrange
            var handler = new UpsertRelationTypeCommand.Handler(_context);

            var name = "Test Relation Type";
            var desc = "Just a test rel type";

            var addDataName = "Test Data 2111";
            var val1Name = "Test Value 2111";
            var val1 = 2111;

            bool trans = true;

            var mirroredType = new RelationType("Mirrored Test Relation");

            _context.RelationTypes.Add(mirroredType);
            await _context.SaveChangesAsync();
            var mirroredTypeId = mirroredType.Id;

            var mirroredTypeDto = new RelationTypeLookupDto { Id = mirroredTypeId };


            var addData = new AdditionalDataObject(addDataName) { Value1Name = val1Name, Value1 = val1 };



            var command = new UpsertRelationTypeCommand(name)
            {
                Description = desc,
                Transitive = trans,
                MirroredType = mirroredTypeDto,
                AdditionalData = new List<AdditionalDataObject> { addData }
            };

            // Act
            var resultId = await handler.Handle(command, CancellationToken.None);


            // Assert
            var actual = await _context.RelationTypes.FirstOrDefaultAsync(x => x.Id == resultId);

            actual.Should().NotBeNull();
            actual.Name.Should().Be(name);
            actual.Description.Should().Be(desc);
            actual.AdditionalData.Should().Contain(addData);
            actual.Transitive.Should().Be(trans);
            actual.MirroredType.Should().BeSameAs(mirroredType);
        }

    }
}
