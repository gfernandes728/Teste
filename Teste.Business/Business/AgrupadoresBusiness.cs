using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Business.Interface;
using Teste.Infra.Interface;
using Teste.Models.ViewModels;

namespace Teste.Business.Business
{
    public class AgrupadoresBusiness : IAgrupadoresBusiness
    {
        private readonly IAgrupadoresRepository _agrupadoresRepository;
        private readonly IUtilsBusiness _utilsBusiness;

        public AgrupadoresBusiness(IAgrupadoresRepository agrupadoresRepository, IUtilsBusiness utilsBusiness)
        {
            _agrupadoresRepository = agrupadoresRepository;
            _utilsBusiness = utilsBusiness;
        }

        public AgrupadoresViewModels ObterDadosIniciais()
            => ObterAgrupadores(string.Empty, ObterDadosAgrupadores(new List<string>()), new List<string>(), new List<AgrupadoresResultadoViewModels>());

        public async Task<AgrupadoresViewModels> ObterDadosSelecionados(AgrupadoresViewModels models)
        {
            var dados = ObterDadosAgrupadores(models.DadosSelecionados);
            if (!models.DadosSelecionados.Any())
                return ObterAgrupadores("Nao possui Dados Selecionados.", dados, new List<string>(), new List<AgrupadoresResultadoViewModels>());

            var lista = await _agrupadoresRepository.ObterAgrupadores(models.DadosSelecionados);

            var resultado = new List<AgrupadoresResultadoViewModels>();
            foreach (var item in lista)
                resultado.Add(_utilsBusiness.Inject(new AgrupadoresResultadoViewModels(), item));

            return ObterAgrupadores(ObterResultado(resultado), dados, models.DadosSelecionados, resultado);
        }

        private string ObterResultado(List<AgrupadoresResultadoViewModels> resultado)
            => resultado.Any() ? $"Total: {resultado.Count}" : "Nao possui Resultado.";

        private AgrupadoresViewModels ObterAgrupadores(string resultado, List<SelectListItem> dados, List<string> dadosSelecionados, List<AgrupadoresResultadoViewModels> agrupadores)
            => new AgrupadoresViewModels()
            {
                Resultado = resultado,
                Dados = dados,
                DadosSelecionados = dadosSelecionados,
                Agrupadores = agrupadores
            };

        private List<SelectListItem> ObterDadosAgrupadores(List<string> selecionados)
            => new List<SelectListItem>()
            {
                _utilsBusiness.ObterSelectItem("t2.Agrupador1", "Agrupador 1", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador2", "Agrupador 2", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador3", "Agrupador 3", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador4", "Agrupador 4", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador5", "Agrupador 5", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador6", "Agrupador 6", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador7", "Agrupador 7", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador8", "Agrupador 8", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador9", "Agrupador 9", selecionados),
                _utilsBusiness.ObterSelectItem("t2.Agrupador10", "Agrupador 10", selecionados),
                _utilsBusiness.ObterSelectItem("t1.UsuarioID", "Usuario", selecionados),
                _utilsBusiness.ObterSelectItem("t3.Nome", "Nome", selecionados),
                _utilsBusiness.ObterSelectItem("t3.Valor", "Valor", selecionados)
            };
    }
}
