using apiViagens.Database;
using apiViagens.Model;
using Microsoft.EntityFrameworkCore;

namespace apiViagens.Repository
{
    public class ClienteRepository : IClienteRepository 
   {
        //injetar dependencia do contexto
        private readonly ClienteDbContext _context;

        public ClienteRepository(ClienteDbContext context) { 
            _context = context;
        }

        public void AddCliente(Cliente Cliente)
        {
            _context.Add(Cliente);
        }

        public void AtualizarCliente(Cliente Cliente)
        {
            _context.Update(Cliente);
        }

        public void DeletarCliente(Cliente Cliente)
        {
            _context.Remove(Cliente);
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _context.Clientes
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}