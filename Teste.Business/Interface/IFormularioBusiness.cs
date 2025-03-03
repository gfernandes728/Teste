using Microsoft.AspNetCore.Http;
using Teste.Models.ViewModels;

namespace Teste.Business.Interface
{
    public interface IFormularioBusiness
    {
        Task<FormularioViewModels> ObterDadosIniciais();
        Task<SelecaoViewModels> ObterSelecao(long selecaoId);
        Task<ArquivosViewModels> ObterArquivo(long arquivoId);
        Task SalvarSelecao(SelecaoViewModels models);
        Task SalvarItem(ItemViewModels models);
        Task SalvarArquivo(IFormFile file, long selecaoId);
    }
}
