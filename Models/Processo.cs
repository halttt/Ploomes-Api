using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Models
{
    public class Processo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string TipoProcesso { get; set; }

        [Required]
        public DateTime DataOcorrencia { get; set; }

        [Required]
        public int AdvogadoId { get; set; }

        [Required]
        public virtual Advogado Advogado { get; set; }
    }
}
