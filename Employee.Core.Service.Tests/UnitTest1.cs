using Moq;
using Moq.Protected;
using Employee.Core.Service;
using Employee.Core.Service.Interfaces;

namespace Employee.Core.Service.Tests
{
    public class UnitTest1
    {
        private Mock<HttpMessageHandler> handlerMock;
        private IEmployeeService service;

        [SetUp]
        public void Setup()
        {
            this.handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            HttpResponseMessage result = new HttpResponseMessage();

            this.handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns(Task.FromResult(result))
            .Verifiable()
            ;

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://www.code4it.dev/")
            };

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(_ => _.CreateClient("ext_service")).Returns(httpClient);

            this.service = new MyExternalService(mockHttpClientFactory.Object);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}