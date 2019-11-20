using Moq;
using NUnit.Framework;
using Rangen.API.Core.Dto.UseCaseResponses;
using Rangen.API.Core.Interfaces;
using Rangen.API.Core.UseCases;
using System.Threading.Tasks;

namespace Rangen.API.Tests
{
    public class CoreTests
    {
        Mock<IItemRepository> moqItemRepo;

        [SetUp]
        public void Setup()
        {
            moqItemRepo = new Mock<IItemRepository>();

        }

        [Test]
        public async Task CanRegisterItemAsync()
        {
            // arrange
            /* moqItemRepo
                .Setup(repo => repo.Create(It.IsAny<Item>()))
                .Returns(Task.FromResult(new CreateItemResponse("", true)))*/

            var mockOutputPort = new Mock<IOutputPort<RegisterItemResponse>>();

            var useCase = new RegisterItemUseCase(moqItemRepo.Object);

            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterItemResponse>()));

            // act

            var response = await useCase.Handle(new RegisterItemRequest("Our world", "The world we are living in right now"), mockOutputPort.Object).ConfigureAwait(false);

            // assert

            Assert.Pass();
        }


    }
}