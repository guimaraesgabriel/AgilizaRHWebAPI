using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilizaRH.Models
{
    public class Cargos
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        public decimal Salario { get; set; }

        public bool Ativo{ get; set; }


        //FK


        //Collections
        public ICollection<CargoGratificacoes> CargoGratificacoes { get; set; }
    }
}
