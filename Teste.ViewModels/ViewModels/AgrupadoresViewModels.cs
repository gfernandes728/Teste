using System.Web.Mvc;

namespace Teste.ViewModels.ViewModels
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

    public class AgrupadoresResultadoViewModels
    {
        public long? Agrupador1 { get; set; }
        public long? Agrupador2 { get; set; }
        public long? Agrupador3 { get; set; }
        public long? Agrupador4 { get; set; }
        public long? Agrupador5 { get; set; }
        public long? Agrupador6 { get; set; }
        public long? Agrupador7 { get; set; }
        public long? Agrupador8 { get; set; }
        public long? Agrupador9 { get; set; }
        public long? Agrupador10 { get; set; }
        public long? UsuarioID { get; set; }
        public DateTime? Data { get; set; }
        public long? Nome { get; set; }
        public DateTime? Valor { get; set; }
        public decimal? Qtd { get; set; }
    }
}
