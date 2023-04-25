using System.ComponentModel.DataAnnotations;
using IT3047C_FinalProj.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    namespace IT3047C_FinalProj.Models
    {
        public class Book
        {
            public int BookId { get; set; }

            [Required(ErrorMessage = "Please enter a title.")]
            public string? Title { get; set; }

            [Required(ErrorMessage = "Please enter an author.")]
            public string? Author { get; set; }

            [Required(ErrorMessage = "Please enter a publication year.")]
            [Range(1450, 2999, ErrorMessage = "Publication year must be after 1450.")]
            public int? PublicationYear { get; set; }

            [Required(ErrorMessage = "Please enter a genre.")]
            public string GenreId { get; set; } = string.Empty;

            [ValidateNever]
            public Genre Genre { get; set; } = null!;

            public string Slug =>
                Title?.Replace(' ', '-').ToLower() + '-' + PublicationYear?.ToString();
        }
    }