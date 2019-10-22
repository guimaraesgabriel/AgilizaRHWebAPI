﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class GruposColaboradores
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Grupo { get; set; }

        public bool Ativo { get; set; }


        //FK
        public int? PermissaoId { get; set; }

        [ForeignKey("PermissaoId")]
        public virtual Permissoes Permissoes { get; set; }


        //Collections
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}