using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
    }
}
