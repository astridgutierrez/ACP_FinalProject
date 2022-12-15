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
    public class DetailsModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public DetailsModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

      public Playlist Playlist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FirstOrDefaultAsync(m => m.PlaylistId == id);
            if (playlist == null)
            {
                return NotFound();
            }
            else 
            {
                Playlist = playlist;
            }
            return Page();
        }
    }
}
