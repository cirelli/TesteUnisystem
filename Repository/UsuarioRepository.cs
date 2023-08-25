using Contracts;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync(CancellationToken cancellationToken)
            => await FindAll()
                .OrderBy(u => u.Nome)
                .ToListAsync(cancellationToken);

        public async Task<Usuario?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await FindByCondition(u => u.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
