using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Models.Models;

namespace Teste.Models.ViewModels
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

    public class FormulariosViewModels : FormulariosModels
    {
    }

    public class ArquivosViewModels : ArquivoModels
    {
    }

    public class ItemViewModels
    {
        public long SelecaoId { get; set; }
        public long FormularioId { get; set; }
        public long CampoId { get; set; }
    }
}
