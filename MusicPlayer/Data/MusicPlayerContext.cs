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
    }
}
