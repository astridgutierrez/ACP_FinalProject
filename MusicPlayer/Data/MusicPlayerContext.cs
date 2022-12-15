using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Models;

namespace MusicPlayer.Data
{
    public class MusicPlayerContext : DbContext
    {
        public MusicPlayerContext (DbContextOptions<MusicPlayerContext> options)
            : base(options)
        {
        }

        public DbSet<MusicPlayer.Models.Song> Song { get; set; } = default!;

        public DbSet<MusicPlayer.Models.Playlist> Playlist { get; set; }

        public DbSet<MusicPlayer.Models.User> User { get; set; }

        public DbSet<MusicPlayer.Models.PlaylistDetails> PlaylistDetails { get; set; }
    }
}
