﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.ViewModels
{
    public class PessoaViewModel
    {
        [Required]
        [Key]
        public int IdPessoa { get; set; }
        
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome da pessoa deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; }
        public string Email { get; set; }
        
        [StringLength(30)]
        public string Rua { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }
        
        [StringLength(30)]
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        
        [StringLength(30)]
        public string Bairro { get; set; }
        public string Estado { get; set; }
    }
}
