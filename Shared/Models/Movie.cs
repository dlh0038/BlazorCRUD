using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Shared.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Rating { get; set; } = string.Empty; //added field
        public string Synopsis {get; set; } = string.Empty;
    }
}