using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly2.Models;

namespace vidly2.ViewModels
{
    public class MovieGenreViewModel
    {    
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }

        [Required]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieGenreViewModel()
        {
            Id = 0;
            ReleaseDate = new DateTime(0001, 01, 01);
            NumberInStock = 0;
        }
        public MovieGenreViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}