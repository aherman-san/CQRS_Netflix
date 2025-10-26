using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Database.Entities
{
    [Table("Actors")]
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotNull]
        [StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        public virtual ICollection<Movie>? Movies { get; set; }

    }
}
