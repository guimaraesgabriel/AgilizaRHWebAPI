using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class CargoGratificacoes
    {
        [Key]
        public int Id { get; set; }


        //FK
        public int CargoId { get; set; }

        [ForeignKey("CargoId")]
        public virtual Cargos Cargos { get; set; }


        public int GratificacaoId { get; set; }

        [ForeignKey("GratificacaoId")]
        public virtual Gratificacoes Gratificacoes { get; set; }


        //Collections
    }
}
