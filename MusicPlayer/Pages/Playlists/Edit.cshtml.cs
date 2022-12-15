using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;

namespace MusicPlayer.Pages.Playlists
{
    public class EditModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public EditModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Playlist Playlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Playlist == null)
            {
                return NotFound();
            }

            var playlist =  await _context.Playlist.FirstOrDefaultAsync(m => m.PlaylistId == id);
            if (playlist == null)
            {
                return NotFound();
            }
            Playlist = playlist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(Playlist.PlaylistId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlaylistExists(int id)
        {
          return _context.Playlist.Any(e => e.PlaylistId == id);
        }
    }
}
