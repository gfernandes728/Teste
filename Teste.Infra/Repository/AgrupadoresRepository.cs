using Dapper;
using Teste.Infra.Interface;
using Teste.Models.DTO;

namespace Teste.Infra.Repository
{
    public class AgrupadoresRepository : IAgrupadoresRepository
    {
        private readonly IUtilsRepository _utilsRepository;

        public AgrupadoresRepository(IUtilsRepository utilsRepository)
            => _utilsRepository = utilsRepository;

        public async Task<List<AgrupadoresResultadoDTO>> ObterAgrupadores(List<string> dados)
        {
            var joinDados = string.Join(", ", dados);

            var query = @$"select {joinDados}, sum(isnull(t1.QTD, 0)) as Qtd
                from dbo.tbTabela1 t1 with(nolock)
                left join dbo.tbTabela2 t2 with(nolock) on t2.Tabela1ID = t1.Tabela1ID
                left join dbo.tbTabela3 t3 with(nolock) on t3.Tabela1ID = t3.Tabela1ID
                group by {joinDados}; ";

             return await _utilsRepository.ObterDados<AgrupadoresResultadoDTO>(query);
        }
    }
}
