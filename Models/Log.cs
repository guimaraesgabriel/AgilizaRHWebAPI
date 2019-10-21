using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Acao { get; set; }

        [MaxLength(2000)]
        public string Descricao { get; set; }

        public DateTime Data { get; set; }


        //FK
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }


        public int TelaId { get; set; }

        [ForeignKey("TelaId")]
        public virtual Telas Telas { get; set; }


        //Collections
    }
}
