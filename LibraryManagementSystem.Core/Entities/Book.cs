using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; } //Author
        public string Category { get; set; } //Genre
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string Thumbnail { get; set; }
        public decimal Rating { get; set; }
        public int Stock { get; set; }
        //public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
