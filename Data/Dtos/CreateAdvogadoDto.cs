using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Data.Dtos
{
    public class CreateAdvogadoDto
    {
        [Required(ErrorMessage = "Nome do advogado é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email do advogado é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone do advogado é obrigatório")]
        public string Telefone { get; set; }

    }
}
