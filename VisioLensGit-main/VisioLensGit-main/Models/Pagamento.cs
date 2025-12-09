namespace VisioLens_Blazor.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public string? Fotografo { get; set; }
        public string? PacoteContratado { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorRestante { get; set; }
        public string? FormaPagamento { get; set; }
        public string? StatusPagamento { get; set; }
    }
}
