using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        //(ErrorMessage ="The field number in Stock must be between 1 and 20")
        [Range(1,20)]
        public int NumberInStock { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId{ get; set; }
    }
}