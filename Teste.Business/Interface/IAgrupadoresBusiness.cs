using Teste.Models.ViewModels;

namespace Teste.Business.Interface
{
    public interface IAgrupadoresBusiness
    {
        AgrupadoresViewModels ObterDadosIniciais();
        Task<AgrupadoresViewModels> ObterDadosSelecionados(AgrupadoresViewModels models);
    }
}
