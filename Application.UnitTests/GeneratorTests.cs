using NUnit.Framework;
using Rangen.Domain.Entities;
using System.Threading.Tasks;

namespace Rangen.Tests
{
    public class GeneratorTests
    {
        GenericOccurrence testGenOcc1, testGenOcc2, testGenOcc3, testGenOcc4, testGenOcc5;
        SpecificOccurrence testSpecOcc1, testSpecOcc2, testSpecOcc3, testSpecOcc4, testSpecOcc5;
        Category testCategory1, testCategory2, testCategory3, testCategory4, testCategory5;



        [SetUp]
        public void Setup()
        {
            string testGenOcc = "Test Generic Occurrence ";
            testGenOcc1 = new GenericOccurrence(testGenOcc + "1");
            testGenOcc2 = new GenericOccurrence(testGenOcc + "2");
            testGenOcc3 = new GenericOccurrence(testGenOcc + "3");
            testGenOcc4 = new GenericOccurrence(testGenOcc + "4");
            testGenOcc5 = new GenericOccurrence(testGenOcc + "5");

            string testSpecOcc = "Test Specific Occurrence ";

            testSpecOcc1 = new SpecificOccurrence(testSpecOcc + "1");
            testSpecOcc2 = new SpecificOccurrence(testSpecOcc + "2");
            testSpecOcc3 = new SpecificOccurrence(testSpecOcc + "3");
            testSpecOcc4 = new SpecificOccurrence(testSpecOcc + "4");
            testSpecOcc5 = new SpecificOccurrence(testSpecOcc + "5");

            string testCat = "Test Category ";

            testCategory1 = new Category(testCat + "1");
            testCategory2 = new Category(testCat + "2");
            testCategory3 = new Category(testCat + "3");
            testCategory4 = new Category(testCat + "4");
            testCategory5 = new Category(testCat + "5");
        }




        [Test]
        public void CanCreateARelationBetweenTwoGenericOccurrences()
        {





        }
        [Test]
        public async Task CanGenerateRandomSpecificOccurrenceInRelationWithTheAlreadyExistingSpecificOccurrence()
        {



        }
        [Test]
        public async Task CanGenerateRandomFamilyForAGivenPersonAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task CanGenerateRandomFamilyForAGivenPersonAndPossesionsForAllOfThemAsync()
        {
            Assert.Fail();
        }
        public async Task CanGenerateRandomCountryWithItsGeographicalElementsAsync()
        {
            Assert.Fail();
        }
    }
}
