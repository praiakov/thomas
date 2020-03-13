using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thomas.App.ViewModels
{
    public class ChamadoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Data de Abertura")]
        public string DataAbertura { get; set; }

        [DisplayName("Data de Fechamento")]
        public string DataFechamento { get; set; }

        [DisplayName("Status")]
        public int TipoStatus { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }

        [NotMapped]         
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}
