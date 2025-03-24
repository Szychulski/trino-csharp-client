using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trino.Client.Logging;

namespace Trino.Client.Test
{
    [TestClass]
    public class StatementClientV1Tests
    {
        [TestMethod]
        public void StatementClientV1ShouldUseCorrectHttpClient()
        {
            // Arrange
            var session = new ClientSession();
            var cancellationToken = new CancellationToken();
            ILoggerWrapper logger = null;

            // Act
            var statementClient = new StatementClientV1(session, cancellationToken, logger);

            // Assert
            var client = statementClient.httpClient;
            var handler = client.GetType().BaseType.GetField("_handler", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(client) as HttpClientHandler;
            Assert.IsNotNull(handler);
            Assert.IsNotNull(handler.ServerCertificateCustomValidationCallback);
        }
    }
}
