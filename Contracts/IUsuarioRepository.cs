using Data.Models;

namespace Contracts
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken cancellationToken);
        Task<Usuario?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
