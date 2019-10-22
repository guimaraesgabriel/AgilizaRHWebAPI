using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgilizaRH.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Senha { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        public bool Ativo { get; set; }


        //FK
        public int GrupoId { get; set; }

        [ForeignKey("GrupoId")]
        public virtual GruposUsuarios GruposColaboradores { get; set; }


        public int CargoIdNovo { get; set; }

        [ForeignKey("CargoIdNovo")]
        public virtual Cargos Cargos { get; set; }


        //Collections
        public ICollection<HistoricoFerias> HistoricoFerias { get; set; }
        public ICollection<HistoricoPromocoes> HistoricoPromocoes { get; set; }
        public ICollection<Log> Log { get; set; }
        public ICollection<UsuarioTelefones> UsuarioTelefones { get; set; }
    }
}
