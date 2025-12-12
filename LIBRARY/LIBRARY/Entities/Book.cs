using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LIBRARY.Entities
{
    public class Book
    {
        public int Id_Book { get; set; }
        [Required,MaxLength(20)]
        public string? Title { get; set; }
        [Required, MaxLength(20)]

        public string? Description { get; set; }
        [Required, MaxLength(20)]

        public string? Author { get; set; }

        public int Id_Type {  get; set; }
    }
}
