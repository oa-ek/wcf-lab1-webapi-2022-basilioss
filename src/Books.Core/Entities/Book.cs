using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public virtual ICollection<Author>? Authors { get; set; } = new List<Author>();
        public Publisher? Publishers { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; } = new List<Genre>();
        public int PageCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishDate { get; set; }
        public string? IconPath { get; set; }
        public float? Rating { get; set; }
        public virtual ICollection<User>? Users { get; set; } = new List<User>();
        public override string ToString()
        {
            return $"{Title}";
        }

    }
}
