using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Data.Dtos
{
    public class UpdateProcessoDto
    {

        public string TipoProcesso { get; set; }

        public DateTime DataOcorrencia { get; set; }
        public int AdvogadoId { get; set; }

    }
}
