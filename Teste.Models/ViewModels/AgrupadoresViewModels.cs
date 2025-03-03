using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Models.Models;

namespace Teste.Models.ViewModels
{
    public class AgrupadoresViewModels
    {
        public AgrupadoresViewModels()
        {
            Dados = new List<SelectListItem>();
            DadosSelecionados = new List<string>();
            Agrupadores = new List<AgrupadoresResultadoViewModels>();
        }

        public string Resultado { get; set; } = string.Empty;
        public List<SelectListItem> Dados { get; set; }
        public List<string> DadosSelecionados { get; set; }
        public List<AgrupadoresResultadoViewModels> Agrupadores { get; set; }
    }

    public class AgrupadoresResultadoViewModels : AgrupadoresResultadoModels
    {
    }
}
