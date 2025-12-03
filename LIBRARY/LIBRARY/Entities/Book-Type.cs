using System.ComponentModel.DataAnnotations;

namespace LIBRARY.Entities
{
    public class Book_Type
    {
        public int Id_Type { get; set; }
        [Required, MaxLength(20)]

        public string Name_Type { get; set; }
        public  int Num_books {get;set;}
    }
}
