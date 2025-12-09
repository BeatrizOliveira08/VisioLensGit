namespace VisioLens_Blazor.Models
{
    public class TipoDeSessao
    {
       public int Id {  get; set; }
       public string? Duracao { get; set; }
       public string? PrecoPadrao { get; set; }
       public string? Quantidade { get; set; }
        public DateTime? Entrega {  get; set; }
        public string? Observaçao { get; set; }
        public string? Categoria { get; set;}

    }
}
