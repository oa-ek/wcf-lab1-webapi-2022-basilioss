using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Books.Core.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
