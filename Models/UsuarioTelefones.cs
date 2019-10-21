using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class UsuarioTelefones
    {
        [Key]
        public int Id { get; set; }


        //FK
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }

        public int TelefoneId { get; set; }

        [ForeignKey("TelefoneId")]
        public virtual Telefones Telefones { get; set; }


        //Collections
    }
}
