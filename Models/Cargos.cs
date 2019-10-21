using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class Cargos
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        public bool Ativo{ get; set; }


        //FK


        //Collections
        public ICollection<CargoGratificacoes> CargoGratificacoes { get; set; }
    }
}
