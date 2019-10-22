using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class Permissoes
    {
        [Key]
        public int Id { get; set; }

        public bool Visualizar { get; set; }

        public bool Adicionar { get; set; }

        public bool Editar { get; set; }

        public bool Excluir { get; set; }


        //FK
        public int TelaId { get; set; }

        [ForeignKey("TelaId")]
        public virtual Telas Telas { get; set; }


        //Collections
        public ICollection<GruposUsuarios> GruposUsuarios { get; set; }

    }
}
