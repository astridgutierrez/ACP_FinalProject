using System.Security.Policy;
using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.Models
{
    public class PlaylistDetails
    {
        public int PlaylistDetailsId { get; set; }
        [Required(ErrorMessage = "Please select a playlist.")]
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public int SongId { get; set; }
        public Song? Song { get; set; }
        
    }
}
