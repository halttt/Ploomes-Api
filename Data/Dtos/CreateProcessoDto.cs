﻿using System.ComponentModel.DataAnnotations;

namespace Ploomers_Advogados.Data.Dtos
{
    public class CreateProcessoDto
    {

        [Required]
        public string TipoProcesso { get; set; }

        [Required]
        public DateTime DataOcorrencia { get; set; }

        [Required]
        public int AdvogadoId { get; set; }

    }
}
