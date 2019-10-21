using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilizaRH.Models
{
    public class Telas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Tela { get; set; }

        [MaxLength(255)]
        public string Caminho { get; set; }


        //FK



        //Collections
        public ICollection<Log> Log { get; set; }
        public ICollection<Permissoes> Permissoes { get; set; }
    }
}
