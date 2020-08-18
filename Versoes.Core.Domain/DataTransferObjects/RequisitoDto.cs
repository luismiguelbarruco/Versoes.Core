using System;
using System.Collections.Generic;
using Versoes.Entities.Models;

namespace Versoes.Entities.DataTransferObjects
{
    public class RequisitoDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<ProjetoDto> Projetos { get; set; } //TODO: Versão do projeto na tabela de relacionamento n .. n
        public ICollection<ClienteDto> Clientes { get; set; } //TODO: Ver como fica o relacionamento com banco externo.
        public DateTime DataCriacao { get; set; }
        public DateTime UltimaAlteracao { get; set; }
        public UsuarioDto CriadoPor { get; set; }
        public UsuarioDto PendentePara { get; set; }
        public ICollection<AnotacaoDto> Anotacoes { get; set; }
        public string Motivacao { get; set; }
        public ushort ValorAgregado { get; set; }
        public Prioridade Prioridade { get; set; }
        public StatusDoRequisito Status { get; set; }
    }
}
