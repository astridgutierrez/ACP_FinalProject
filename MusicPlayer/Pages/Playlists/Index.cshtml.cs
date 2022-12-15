using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;

namespace MusicPlayer.Pages.Playlists
{
    public class IndexModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public IndexModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

        public IList<Playlist> Playlist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Playlist != null)
            {
                Playlist = await _context.Playlist.ToListAsync();
            }
        }
    }
}
