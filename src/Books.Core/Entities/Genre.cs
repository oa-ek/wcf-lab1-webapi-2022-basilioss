using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Entities
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? GenreName { get; set; }
        public virtual ICollection<Book>? Books { get; set; } = new List<Book>();
        public override string ToString()
        {
            return $"{GenreName} ";
        }
    }
}
