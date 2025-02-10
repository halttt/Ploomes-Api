using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Data.Dtos
{
    public class ReadAdvogadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public ICollection<ReadProcessoDto> Processos { get; set; }
    }
}
