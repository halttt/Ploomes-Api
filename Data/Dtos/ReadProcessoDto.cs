
namespace Ploomers_Advogados.Data.Dtos
{
    public class ReadProcessoDto
    {
      
        public int Id { get; set; }

        public string TipoProcesso { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public int AdvogadoId { get; set; }

    }
}
