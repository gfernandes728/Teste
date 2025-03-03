namespace Teste.Infra.Interface
{
    public interface IUtilsRepository
    {
        Task<T?> ObterDado<T>(string query, object parametro);
        Task<List<T>> ObterDados<T>(string query);
        Task<List<T>> ObterDadosComParametros<T>(string query, object parametros);
        Task<int> SalvarDados(string query);
        Task<int> SalvarDadosComParametros(string query, object parametros);
    }
}
