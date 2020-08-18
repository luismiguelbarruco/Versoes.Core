namespace Versoes.Entities.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
    }
}
