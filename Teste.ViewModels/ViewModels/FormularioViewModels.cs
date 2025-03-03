using System.Web.Mvc;

namespace Teste.ViewModels.ViewModels
{
    public class FormularioViewModels
    {
        public FormularioViewModels()
        {
            Selecoes = new List<SelectListItem>();
            SelecaoIds = new List<long>();
        }

        public List<SelectListItem> Selecoes { get; set; }
        public List<long> SelecaoIds { get; set; }
    }

    public class SelecaoViewModels
    {
        public SelecaoViewModels()
        {
            Campos = new List<SelectListItem>();
            CampoIds = new List<long>();
            Formularios = new List<FormulariosViewModels>();
            Arquivos = new List<ArquivosViewModels>();
        }

        public long SelecaoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public List<SelectListItem> Campos { get; set; }
        public List<long> CampoIds { get; set; }
        public List<FormulariosViewModels> Formularios { get; set; }
        public List<ArquivosViewModels> Arquivos { get; set; }
    }

    public class FormulariosViewModels
    {
        public long FormularioId { get; set; }
        public long CampoId { get; set; }
        public string Nome { get; set; } = string.Empty;
    }

    public class ArquivosViewModels
    {
        public long ArquivoId { get; set; }
        public long SelecaoId { get; set; }
        public byte[] Arquivo { get; set; } = new byte[] { };
    }

    public class ItemViewModels
    {
        public long SelecaoId { get; set; }
        public long FormularioId { get; set; }
        public long CampoId { get; set; }
    }
}
