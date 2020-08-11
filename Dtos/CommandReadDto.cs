using System.ComponentModel.DataAnnotations;

namespace commander.Dtos
{
    public class CommandReadDto
    {
        
        public int Id { get; set; }
        public string Howto { get; set; }
        public string Line { get; set; }
        
        }
}