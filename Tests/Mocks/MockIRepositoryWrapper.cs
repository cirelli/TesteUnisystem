using Contracts;
using Moq;

namespace Tests.Mocks
{
    internal static class MockIRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();

            mock.Setup(m => m.Usuario)
                .Returns(() => MockIUsuarioRepository.GetMock().Object);

            mock.Setup(m => m.SaveAsync(It.IsAny<CancellationToken>()))
                .Returns((CancellationToken token) => Task.CompletedTask);

            return mock;
        }
    }
}
