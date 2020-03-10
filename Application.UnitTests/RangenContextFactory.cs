using Microsoft.EntityFrameworkCore;
using Rangen.Domain.Entities;
using Rangen.Persistence;
using System;

namespace Rangen.Application.UnitTests
{
    public class RangenContextFactory
    {

        public static RangenDbContext Create()
        {
            var options = new DbContextOptionsBuilder<RangenDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new RangenDbContext(options);

            context.Database.EnsureCreated();

            string testGenOcc = "Test Generic Occurrence ";
            context.GenericOccurrences.AddRange(new[] {
                new GenericOccurrence(testGenOcc + "1"),
            new GenericOccurrence(testGenOcc + "2"),
            new GenericOccurrence(testGenOcc + "3"),
            new GenericOccurrence(testGenOcc + "4"),
            new GenericOccurrence(testGenOcc + "5"),
            new GenericOccurrence(testGenOcc + "6")
            });


            string testSpecOcc = "Test Specific Occurrence ";
            context.SpecificOccurrences.AddRange(new[] {
            new SpecificOccurrence(testSpecOcc + "1"),
            new SpecificOccurrence(testSpecOcc + "2"),
            new SpecificOccurrence(testSpecOcc + "3") ,
            new SpecificOccurrence(testSpecOcc + "4") ,
            new SpecificOccurrence(testSpecOcc + "5"),
        });


            string testCat = "Test Category ";
            context.Categories.AddRange(new[] {
            new Category(testCat + "1"),
            new Category(testCat + "2"),
            new Category(testCat + "3"),
            new Category(testCat + "4")
            });


            string testCatType = "Test Category Type";
            context.CategoryTypes.AddRange(new[]
            {
                new CategoryType(testCatType + "1"),
                new CategoryType(testCatType + "2")
            });

            string testRelType = "Test Relation Type ";
            context.RelationTypes.AddRange(new[] {
            new RelationType(testRelType + "1"),
            new RelationType(testRelType + "2"),
            new RelationType(testRelType + "3")
            });



            string testRelation = "Test Relation";

            var occ1 = new GenericOccurrence("Gen Occ as Occurrence 1 in Relation");
            var occ2 = new SpecificOccurrence("Spec Occ as Occurrence 2 in Relation");
            var relation1 = new Relation(testRelation + "1") { Occurrence1 = occ1, Occurrence2 = occ2 };

            context.GenericOccurrences.Add(occ1);
            context.SpecificOccurrences.Add(occ2);
            context.Relations.Add(relation1);

            context.SaveChanges();

            return context;
        }

        public static void Destroy(RangenDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
