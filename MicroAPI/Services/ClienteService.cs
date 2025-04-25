using MicroAPI.Models;

namespace MicroAPI.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes = new();
        private int _IdAtual = 1;

        public List<Cliente> ObterTodos() => _clientes;

        public Cliente ObterPorId(int id) => _clientes.FirstOrDefault(c => c.Id == id);

        public Cliente Adicionar(Cliente cliente)
        {
            cliente.Id = _IdAtual++;
            _clientes.Add(cliente);
            return cliente;
        }
    }
}
