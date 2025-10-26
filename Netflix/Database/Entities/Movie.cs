using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Database.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        [NotNull]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [NotNull]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [NotNull]
        [StringLength(1000)]
        public string Image { get; set; } = string.Empty;

        [NotNull]
        [StringLength(1000)]
        public string Url { get; set; } = string.Empty;

        public int Year { get; set; }

        [NotNull]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [NotNull]
        [StringLength(20)]
        public string Time { get; set; } = string.Empty;

        public virtual Category? Category { get; set; }

        public virtual ICollection<Actor>? Actors { get; set; }

    }
}
