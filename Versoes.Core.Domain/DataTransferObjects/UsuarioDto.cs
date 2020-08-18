namespace Versoes.Entities.DataTransferObjects
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public SetorDto Setor { get; set; }
        public StatusDeCadastro Status { get; set; }
        public string Login { get; set; }
    }
}
