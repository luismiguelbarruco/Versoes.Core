namespace Versoes.Entities.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public long SetorId { get; set; }
        public Setor Setor { get; set; }
    }
}
