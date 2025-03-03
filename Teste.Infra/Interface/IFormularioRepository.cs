using static Teste.Models.DTO.FormularioDTO;

namespace Teste.Infra.Interface
{
    public interface IFormularioRepository
    {
        Task<List<ListasDTO>> ObterSelecoes();
        Task<List<ListasDTO>> ObterCampos();
        Task<List<FormulariosDTO>> ObterFormulario(long selecaoId);
        Task<List<ArquivoDTO>> ObterArquivos(long selecaoId);
        Task<ArquivoDTO> ObterArquivo(long arquivoId);
        Task<int> SalvarCampos(long selecaoId, List<long> campoIds);
        Task<int> SalvarItem(long selecaoId, long campoId, long formularioId);
        Task<int> SalvarArquivo(long selecaoId, byte[] arquivo);
    }
}
