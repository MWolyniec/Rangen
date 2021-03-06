﻿using Microsoft.EntityFrameworkCore;
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


            string testRelType = "Test Relation Type ";
            context.RelationTypes.AddRange(new[] {
            new RelationType(testRelType + "1"),
            new RelationType(testRelType + "2"),
            new RelationType(testRelType + "3")
            });

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
