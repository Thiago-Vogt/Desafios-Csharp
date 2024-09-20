using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace PontosAPI.Interfaces
{
    public interface IRepository<T, t, cpf>
    {
        T Get(cpf Cpf);
        void AtualizarPontos(t id, int pontos);
    }
}
