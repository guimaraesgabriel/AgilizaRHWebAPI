using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class HistoricoPromocoes
    {
        [Key]
        public int Id { get; set; }


        //FK
        public int CargoIdAnterior { get; set; }

        [ForeignKey("CargoIdAnterior")]
        public virtual Cargos CargoAnterior { get; set; }


        public int CargoIdNovo { get; set; }

        [ForeignKey("CargoIdNovo")]
        public virtual Cargos CargoNovo { get; set; }


        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }


        //Collections
    }
}
