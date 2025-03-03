namespace Teste.Models.Models
{
    public class ArquivoModels
    {
        public long ArquivoId { get; set; }
        public long SelecaoId { get; set; }
        public byte[] Arquivo { get; set; } = new byte[] { };
    }

    public class FormulariosModels
    {
        public long FormularioId { get; set; }
        public long CampoId { get; set; }
        public string Nome { get; set; } = string.Empty;
    }


    public class AgrupadoresResultadoModels
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
