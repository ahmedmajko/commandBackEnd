using System.ComponentModel.DataAnnotations;

namespace commander.Models
{
    public class command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Howto { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}