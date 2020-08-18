namespace Versoes.Entities.Models
{
    public class Bug : Lancamento
    {
        public Criticidade Criticidade { get; set; }
        public StatusDoBug Status { get; set; }
    }

    public enum Criticidade
    {
        Baixo,
        Medio,
        Alto,
        Critico
    }

    public enum StatusDoBug
    {
        Novo,
        Verificado,
        Corrigindo,
        Pronto
    }
}
