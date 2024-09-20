using PontosAPI.Interfaces;
using PontosAPI.Models;

namespace PontosAPI.Services
{
    public class ClientePontosService
    {
        private readonly IRepository<ClientePontos, int, string> _repository;

        public ClientePontosService(IRepository<ClientePontos, int, string> repository)
        {
            _repository = repository;
        }

        public ClientePontos GetCliente(string Cpf)
        {
            return _repository.Get(Cpf);
        }

        public void AdicionarPontos(int id, int pontos)
        {
            _repository.AtualizarPontos(id, pontos);
        }
    }
}
