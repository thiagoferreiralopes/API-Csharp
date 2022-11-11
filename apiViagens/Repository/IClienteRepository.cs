using apiViagens.Model;

namespace apiViagens.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetUsuarios();
        Task<Cliente> GetClienteById(int id);
        void AddCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
        Task<bool> SaveChangesAsync();
        
    }
}