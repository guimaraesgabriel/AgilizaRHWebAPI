using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class HistoricoFerias
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataFerias { get; set; }

        public DateTime? PrevisaoFerias { get; set; }


        //FK
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }


        //Collections
    }
}
