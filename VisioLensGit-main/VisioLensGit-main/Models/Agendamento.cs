namespace VisioLens_Blazor.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public DateTime Data {  get; set; }
        public string? TipoDeSessao { get; set; }
        public string? Duracao { get; set; }
        public string? Fotografo { get; set; }
        public string? Observacao { get; set;}
    }
}
