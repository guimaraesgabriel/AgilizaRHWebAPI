using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class Gratificacoes
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Tipo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Valor { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Porcentagem { get; set; }

        public bool Ativo { get; set; }


        //FK



        //Collections
        public ICollection<CargoGratificacoes> CargoGratificacoes { get; set; }
    }
}
