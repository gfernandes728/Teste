using Dapper;
using Teste.Infra.Interface;
using static Teste.Models.DTO.FormularioDTO;

namespace Teste.Infra.Repository
{
    public class FormularioRepository : IFormularioRepository
    {
        private readonly IUtilsRepository _utilsRepository;

        public FormularioRepository(IUtilsRepository utilsRepository)
            => _utilsRepository = utilsRepository;

        public async Task<List<ListasDTO>> ObterSelecoes()
            => await _utilsRepository.ObterDados<ListasDTO>("select SelecaoId as Id, Nome from dbo.tbSelecoes with(nolock) order by Nome;");

        public async Task<List<ListasDTO>> ObterCampos()
            => await _utilsRepository.ObterDados<ListasDTO>("select CampoId as Id, Nome from dbo.tbCampos with(nolock) order by Nome;");

        public async Task<List<FormulariosDTO>> ObterFormulario(long selecaoId)
        {
            var query = "select f.FormularioId, c.CampoId, c.Nome from dbo.tbFormularios f with(nolock) join dbo.tbCampos c with(nolock) on c.CampoId = f.CampoId  where f.SelecaoId = @SelecaoId;";
            return await _utilsRepository.ObterDadosComParametros<FormulariosDTO>(query, new { @SelecaoId = selecaoId });
        }

        public async Task<List<ArquivoDTO>> ObterArquivos(long selecaoId)
            => await _utilsRepository.ObterDadosComParametros<ArquivoDTO>("select ArquivoId, SelecaoId from dbo.tbArquivos with(nolock) where SelecaoId = @SelecaoId;", new { @SelecaoId = selecaoId });

        public async Task<ArquivoDTO> ObterArquivo(long arquivoId)
        {
            var query = "select top 1 Arquivo from dbo.tbArquivos with(nolock) where ArquivoId = @ArquivoId;";
            var resultado = await _utilsRepository.ObterDado<ArquivoDTO>(query, new { @ArquivoId = arquivoId });
            if (resultado == null)
                return new ArquivoDTO();

            return resultado;
        }

        public async Task<int> SalvarCampos(long selecaoId, List<long> campoIds)
        {
            var insert = new List<string>();
            foreach (var item in campoIds)
                insert.Add($"( {selecaoId}, {item} )");

            return await _utilsRepository.SalvarDados($"insert into dbo.tbFormularios values {string.Join(", ", insert)};");
        }

        public async Task<int> SalvarItem(long selecaoId, long campoId, long formularioId)
            => await _utilsRepository.SalvarDadosComParametros("update dbo.tbFormularios set CampoId = @CampoId where SelecaoId = @SelecaoId and FormularioId = @FormularioId;", new
            {
                @CampoId = campoId,
                @SelecaoId = selecaoId,
                @FormularioId = formularioId
            });

        public async Task<int> SalvarArquivo(long selecaoId, byte[] arquivo)
            => await _utilsRepository.SalvarDadosComParametros("insert into dbo.tbArquivos ( SelecaoId, Arquivo ) values ( @SelecaoId, @Arquivo );", new
            {
                @SelecaoId = selecaoId,
                @Arquivo = arquivo
            });
    }
}
