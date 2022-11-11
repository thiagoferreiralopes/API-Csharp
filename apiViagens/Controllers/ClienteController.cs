using Microsoft.AspNetCore.Mvc;
using apiViagens.Model;
using apiViagens.Repository;
using apiViagens.Properties;

namespace apiViagens.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        //injetar dependencia do repositorio
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Clientes = await _repository.GetClientes();
            return Clientes.Any() ? Ok(Clientes) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Cliente = await _repository.GetClienteById(id);
            return Cliente != null
            ? Ok(Cliente) : NotFound("Usuário não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente Cliente)
        {
            _repository.AddCliente(Cliente);
            return await _repository.SaveChangesAsync()
            ? Ok("Usuário adicionado") : BadRequest("Algo deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Cliente Cliente)
        {
            var ClienteExiste = await _repository.GetClienteById(id);
            if (ClienteExiste == null) return NotFound("Usuário não encontrado");

            ClienteExiste.Nome = Cliente.Nome ?? ClienteExiste.Nome;
            ClienteExiste.Email = Cliente.Email
            ? Cliente.Email : ClienteExiste.Email;

            _repository.AtualizarCliente(ClienteExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário atualizado.") : BadRequest("Algo deu errado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ClienteExiste = await _repository.GetClienteById(id);
            if (ClienteExiste == null)
                return NotFound("Cliente não encontrado");

            _repository.DeletarCliente(ClienteExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cliente deletado.") : BadRequest("Algo deu errado.");
        }

    }
}