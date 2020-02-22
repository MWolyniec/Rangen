using MediatR;
using Moq;
using NUnit.Framework;
using System.Threading;

namespace Rangen.Application.UnitTests.Commands
{
    public class CreateRelation : CommandTestBase
    {
        [Test]

        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateRelationCommand.Handler(_context, mediatorMock.Object);
            var newCustomerId = "QAZQ1";

            // Act
            var result = sut.Handle(new CreateRelationCommand { Id = newCustomerId }, CancellationToken.None);


            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<RelationCreated>(cc => cc.CustomerId == newCustomerId), It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
