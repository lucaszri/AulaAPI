﻿using System.ComponentModel.DataAnnotations;

namespace API_Pessoa
{
    public class Pessoa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome é obrigatório!")]
        [MaxLength(255)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        [Range(0, 20)]
        public int QuantidadeFilhos { get; set; }
        public int Idade => DateTime.Now.AddYears(-DataNascimento.Year).Year;
    }
}
