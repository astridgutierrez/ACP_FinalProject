using System.Security.Policy;

namespace MusicPlayer.Models
{
    public class PlaylistDetails
    {
        public int PlaylistDetailsId { get; set; }
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public int SongId { get; set; }
        
    }
}
