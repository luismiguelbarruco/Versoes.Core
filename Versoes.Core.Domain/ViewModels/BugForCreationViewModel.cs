﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.ViewModels
{
    public class BugForCreationViewModel
    {
        [Required(ErrorMessage = "Descrição é obrigatória.")]
        [StringLength(300, ErrorMessage = "Descrição não pode ser superior a 300 caracteres.")]
        public string Descricao { get; set; }
        public ICollection<ProjetoViewModel> Projetos { get; set; } //TODO: Versão do projeto na tabela de relacionamento n .. n
        public ICollection<ClienteViewModel> Clientes { get; set; } //TODO: Ver como fica o relacionamento com banco externo.
        public UsuarioViewModel CriadoPor { get; set; } //TODO: Manter no Dto ou pegar automaticamente o usuário logado?

        public UsuarioViewModel PendentePara { get; set; }
        public ICollection<AnotacaoVireModel> Anotacoes { get; set; }

        public Criticidade Criticidade { get; set; }
    }
}