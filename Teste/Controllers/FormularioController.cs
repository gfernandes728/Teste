using Microsoft.AspNetCore.Mvc;
using Teste.Business.Interface;
using Teste.Models.ViewModels;

namespace Teste.Controllers
{
    public class FormularioController : Controller
    {
        private readonly IFormularioBusiness _formularioBusiness;

        public FormularioController(IFormularioBusiness formularioBusiness)
            => _formularioBusiness = formularioBusiness;

        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await _formularioBusiness.ObterDadosIniciais());

        [HttpGet]
        public async Task<IActionResult> ObterSelecao(long selecaoId)
            => PartialView("_Selecao2", await _formularioBusiness.ObterSelecao(selecaoId));

        [HttpPost]
        public async Task<IActionResult> SalvarSelecao(SelecaoViewModels models)
        {
            await _formularioBusiness.SalvarSelecao(models);
            return Json("ok");
        }

        [HttpPost]
        public async Task<IActionResult> SalvarItem(ItemViewModels models)
        {
            await _formularioBusiness.SalvarItem(models);
            return Json("ok");
        }

        [HttpPost]
        public async Task<IActionResult> SalvarArquivo(IFormFile file, long selecaoId)
        {
            if (file != null && file.Length > 0)
                await _formularioBusiness.SalvarArquivo(file, selecaoId);

            return Json("ok");
        }

        [HttpGet]
        public async Task<IActionResult> ObterArquivo(long arquivoId)
        {
            var arquivo = await _formularioBusiness.ObterArquivo(arquivoId);
            if (arquivo == null || arquivo.Arquivo == null)
                return NotFound();

            return File(arquivo.Arquivo, "application/*");
        }
    }
}
