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
    public class DeleteModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public DeleteModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }
            var playlist = await _context.Playlist.FindAsync(id);

            if (playlist != null)
            {
                Playlist = playlist;
                _context.Playlist.Remove(Playlist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
