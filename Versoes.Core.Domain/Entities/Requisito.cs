namespace Versoes.Entities.Models
{
    public class Requisito : Lancamento
    {
        public string Motivacao { get; set; }
        public ushort ValorAgregado { get; set; }
        public Prioridade Prioridade { get; set; }
        public StatusDoRequisito Status { get; set; }
    }

    public enum Prioridade
    {
        Baixa,
        Media,
        Alta
    }

    public enum StatusDoRequisito
    {
        Novo,
        Verificado,
        Desenvolvimento,
        Pronto
    }
}
