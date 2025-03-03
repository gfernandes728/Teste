using Dapper;
using Teste.Infra.Interface;
using static Teste.Models.DTO.FormularioDTO;

namespace Teste.Infra.Repository
{
    public class UtilsRepository : IUtilsRepository
    {
        private readonly DbDapperContext _db;

        public UtilsRepository(DbDapperContext db)
            => _db = db;

        public async Task<T?> ObterDado<T>(string query, object parametro)
            => await _db.DapperConnection.QueryFirstOrDefaultAsync<T>(query, parametro);

        public async Task<List<T>> ObterDados<T>(string query)
            => (await _db.DapperConnection.QueryAsync<T>(query)).ToList();

        public async Task<List<T>> ObterDadosComParametros<T>(string query, object parametros)
            => (await _db.DapperConnection.QueryAsync<T>(query, parametros)).ToList();

        public async Task<int> SalvarDados(string query)
            => await _db.DapperConnection.ExecuteAsync(query);

        public async Task<int> SalvarDadosComParametros(string query, object parametros)
            => await _db.DapperConnection.ExecuteAsync(query, parametros);
    }
}
