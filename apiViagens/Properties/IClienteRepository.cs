using apiViagens.Model;

namespace apiViagens.Properties
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetClienteById(int id);
        void AddCliente(Cliente Cliente);
        void AtualizarCliente(Cliente Cliente);
        void DeletarCliente(Cliente Cliente);

        Task<bool> SaveChangesAsync();
    }
}