using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Models
{
    public class Advogado
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        public virtual ICollection<Processo> Processos { get; set; }



    }
}
