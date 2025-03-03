using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Omu.ValueInjecter;
using Teste.Business.Interface;
using Teste.Infra.Interface;
using Teste.Models.ViewModels;
using static Teste.Models.DTO.FormularioDTO;

namespace Teste.Business.Business
{
    public class FormularioBusiness : IFormularioBusiness
    {
        private readonly IFormularioRepository _formularioRepository;
        private readonly IUtilsBusiness _utilsBusiness;

        public FormularioBusiness(IFormularioRepository formularioRepository, IUtilsBusiness utilsBusiness)
        {
            _formularioRepository = formularioRepository;
            _utilsBusiness = utilsBusiness;
        }

        public async Task<FormularioViewModels> ObterDadosIniciais()
            => await ObterFormulario(new List<long>());

        private async Task<FormularioViewModels> ObterFormulario(List<long> selecaoIds)
        {
            var selecoes = ObterSelecoes(await _formularioRepository.ObterSelecoes(), selecaoIds);

            return new FormularioViewModels()
            {
                Selecoes = selecoes,
                SelecaoIds = selecaoIds
            };
        }

        public async Task<SelecaoViewModels> ObterSelecao(long selecaoId)
        {
            var campos = ObterSelecoes(await _formularioRepository.ObterCampos(), new List<long>());

            var formularios = await _formularioRepository.ObterFormulario(selecaoId);
            var resultadoFormularios = new List<FormulariosViewModels>();

            foreach (var item in formularios)
                resultadoFormularios.Add(_utilsBusiness.Inject(new FormulariosViewModels(), item));

            var arquivos = await _formularioRepository.ObterArquivos(selecaoId);
            var resultadoArquivos = new List<ArquivosViewModels>();

            foreach (var item in arquivos)
                resultadoArquivos.Add(_utilsBusiness.Inject(new ArquivosViewModels(), item));

            return new SelecaoViewModels()
            {
                SelecaoId = selecaoId,
                Titulo = $"Selecao {selecaoId}",
                Campos = campos,
                CampoIds = new List<long>(),
                Formularios = resultadoFormularios,
                Arquivos = resultadoArquivos
            };
        }

        public async Task SalvarArquivo(IFormFile file, long selecaoId)
        {
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            if (fileBytes != null)
                await _formularioRepository.SalvarArquivo(selecaoId, fileBytes);
        }

        public async Task<ArquivosViewModels> ObterArquivo(long arquivoId)
        {
            var resultado = await _formularioRepository.ObterArquivo(arquivoId);
            if (resultado == null)
                return new ArquivosViewModels();

            return _utilsBusiness.Inject(new ArquivosViewModels(), resultado);
        }

        public async Task SalvarSelecao(SelecaoViewModels models)
            => await _formularioRepository.SalvarCampos(models.SelecaoId, models.CampoIds);

        public async Task SalvarItem(ItemViewModels models)
            => await _formularioRepository.SalvarItem(models.SelecaoId, models.CampoId, models.FormularioId);

        private List<SelectListItem> ObterSelecoes(List<ListasDTO> listas, List<long> ids)
        {
            var lista = new List<SelectListItem>();

            foreach (var item in listas)
                lista.Add(_utilsBusiness.ObterSelectItem(item.Id, item.Nome, ids));

            return lista;
        }
    }
}
