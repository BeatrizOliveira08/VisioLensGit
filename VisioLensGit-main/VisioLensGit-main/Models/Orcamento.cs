namespace VisioLens_Blazor.Models
{
    public class Orcamento
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public string? Fotografo { get; set;}
        public string? PacoteDeFotos { get; set;}
        public string? ValorTotal { get; set; }
        public string? Status { get; set; }
        public string? FormaDePagamento { get; set; }
        public string? TipoDeSessao { get; set; }
    }
}
