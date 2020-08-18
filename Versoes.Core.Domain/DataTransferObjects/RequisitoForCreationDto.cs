using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class RequisitoForCreationDto
    {
        [Required(ErrorMessage = "Descrição é obrigatória.")]
        [StringLength(300, ErrorMessage = "Descrição não pode ser superior a 300 caracteres.")]
        public string Descricao { get; set; }

        public ICollection<ProjetoDto> Projetos { get; set; } //TODO: Versão do projeto na tabela de relacionamento n .. n
        public ICollection<ClienteDto> Clientes { get; set; } //TODO: Ver como fica o relacionamento com banco externo.
        public UsuarioDto CriadoPor { get; set; } //TODO: Manter no Dto ou pegar automaticamente o usuário logado?
        public UsuarioDto PendentePara { get; set; }
        public ICollection<AnotacaoDto> Anotacoes { get; set; }
        public string Motivacao { get; set; }

        [Range(0, 10, ErrorMessage = "Valor agregado deve estar entre 1 e 10.")]
        public ushort ValorAgregado { get; set; }
        public Prioridade Prioridade { get; set; }
        public StatusDoRequisito Status { get; set; }
    }
}
