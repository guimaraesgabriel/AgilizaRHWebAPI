using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilizaRH.Models
{
    public class Gratificacoes
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Tipo { get; set; }

        public decimal? Valor { get; set; }

        public decimal? Porcentagem { get; set; }

        public bool Ativo { get; set; }


        //FK



        //Collections
        public ICollection<CargoGratificacoes> CargoGratificacoes { get; set; }
    }
}
