using Moq;
using NUnit.Framework;
using Rangen.Entities.POCO;
using Rangen.UseCases.MarkForDeletionAndDelete;
using Rangen.UseCases.RegisterAndCreate;
using Rangen.UseCases.RegisterAndCreate.Specific;
using Rangen.UseCases.UseCasesBaseClasses;
using System.Threading.Tasks;

namespace Rangen.UseCases.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CanRegisterAndCreateNewItemAsync()
        {
            var mockItemRepository = new Mock<IItemRepository>();
            mockItemRepository
              .Setup(repo => repo.Create(It.IsAny<Brick>()))
              .Returns(Task.FromResult(new CreateItemResponse("", true)));


            var useCase = new RegisterBrickUseCase(mockItemRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<RegisterItemResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<RegisterItemResponse>()));

            var response = await useCase.Handle
                (new RegisterItemRequest("Name: register test item", "Desc: just a test item"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
        [Test]
        public async Task CanRequestDeletionAndDeleteAnItemByIdAsync()
        {
            int id = 20;

            var mockItemRepository = new Mock<IItemRepository>();
            mockItemRepository
              .Setup(repo => repo.Delete(It.Is<Item>(x => x.Id == id)))
              .Returns(Task.FromResult(new DeleteItemResponse("", true)));

            var useCase = new MarkItemForDeletionUseCase(mockItemRepository.Object);

            var mockOutputPort = new Mock<IOutputPort<MarkItemForDeletionResponse>>();

            var response = await useCase.Handle(new MarkBrickForDeletionRequest(id + 1), mockOutputPort.Object);

            Assert.True(response);
        }
    }
}