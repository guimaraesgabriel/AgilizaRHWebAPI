using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class UsuarioTelefones
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        public bool Ativo { get; set; }


        //FK
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuarios { get; set; }


        //Collections
    }
}
