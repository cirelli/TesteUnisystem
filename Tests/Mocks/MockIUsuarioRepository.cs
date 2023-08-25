using Contracts;
using Data.Models;
using Moq;

namespace Tests.Mocks
{
    internal static class MockIUsuarioRepository
    {
        public static Mock<IUsuarioRepository> GetMock()
        {
            var mock = new Mock<IUsuarioRepository>();
            var usuarios = new List<Usuario>()
            {
                new Usuario { Id = 1, Nome = "Usuário 1" },
                new Usuario { Id = 2, Nome = "Usuário 2" },
                new Usuario { Id = 3, Nome = "Usuário 3" }
            };

            mock.Setup(m => m.GetAllAsync(It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(usuarios.AsEnumerable()));

            mock.Setup(m => m.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .Returns((int id, CancellationToken token) => Task.FromResult(usuarios.FirstOrDefault(o => o.Id == id)));

            mock.Setup(m => m.Create(It.IsAny<Usuario>()))
                .Callback(() => { return; });

            mock.Setup(m => m.Update(It.IsAny<Usuario>()))
               .Callback(() => { return; });

            mock.Setup(m => m.Delete(It.IsAny<Usuario>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}
