using Teste.Models.DTO;

namespace Teste.Infra.Interface
{
    public interface IAgrupadoresRepository
    {
        Task<List<AgrupadoresResultadoDTO>> ObterAgrupadores(List<string> dados);
    }
}
