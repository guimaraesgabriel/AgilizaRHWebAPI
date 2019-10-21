using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilizaRH.Models
{
    public class Telefones
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Numero { get; set; }

        public bool Ativo { get; set; }



        //FK



        //Collections
        public ICollection<UsuarioTelefones> UsuarioTelefones { get; set; }
    }
}
