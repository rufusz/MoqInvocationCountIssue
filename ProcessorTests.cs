using Moq;
using NUnit.Framework;
using static TestMoq2.Program;

namespace TestMoq2
{
   [TestFixture]
   public class ProcessorTests
   {
      private Mock<IService> _serviceMock;
      private Processor _processor;

      [SetUp]
      public void Setup()
      {
         _serviceMock = new Mock<IService>();
         _processor = new Processor(_serviceMock.Object);
      }

      [Test]
      public void Test()
      {
         /*_serviceMock.Setup(service => service.DoSomething(
            It.Is<InputParameters>(input => input.x == 5)
         )).Returns(() => true);

         _serviceMock.Setup(service => service.DoSomething(
            It.Is<InputParameters>(input => input.x == 50)
         )).Returns(() => false);*/

         _serviceMock.Setup(service => service.DoSomething(
            It.IsAny<InputParameters>()
         ));

         _processor.Process();

         _serviceMock.Verify(service => service.DoSomething(
            It.Is<InputParameters>(input => input.x == 5)
         ), Times.Exactly(1)); //returns 0 instead of 1

         _serviceMock.Verify(service => service.DoSomething(
            It.Is<InputParameters>(input => input.x == 100)
         ), Times.Exactly(1)); //returns 2 instead of 1

         Assert.NotNull(_processor);
      }
   }
}
