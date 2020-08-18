﻿using System.ComponentModel.DataAnnotations;
using Versoes.Core.Domain.DataTransferObjects;

namespace Versoes.Entities.DataTransferObjects
{
    public class UsuarioForCreationDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ser maior que 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Setor obrigatório")]
        public SetorDto Setor { get; set; }

        public StatusDeCadastro Status { get; set; }

        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
