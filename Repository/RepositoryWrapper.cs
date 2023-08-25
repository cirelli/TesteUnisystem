using Contracts;
using Data;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext dataContext;
        private IUsuarioRepository? usuario;

        public IUsuarioRepository Usuario
        {
            get
            {
                usuario ??= new UsuarioRepository(dataContext);
                return usuario;
            }
        }

        public RepositoryWrapper(DataContext repositoryContext)
        {
            dataContext = repositoryContext;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
