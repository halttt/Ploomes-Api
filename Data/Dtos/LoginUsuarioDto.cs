using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Data.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
