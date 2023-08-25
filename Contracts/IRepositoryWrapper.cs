namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUsuarioRepository Usuario { get; }

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
