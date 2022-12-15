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

namespace MusicPlayer.Pages.PlaylistsDetails
{
    public class EditModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public EditModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlaylistDetails PlaylistDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlaylistDetails == null)
            {
                return NotFound();
            }

            var playlistdetails =  await _context.PlaylistDetails.FirstOrDefaultAsync(m => m.PlaylistDetailsId == id);
            if (playlistdetails == null)
            {
                return NotFound();
            }
            PlaylistDetails = playlistdetails;
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

            _context.Attach(PlaylistDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistDetailsExists(PlaylistDetails.PlaylistDetailsId))
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

        private bool PlaylistDetailsExists(int id)
        {
          return _context.PlaylistDetails.Any(e => e.PlaylistDetailsId == id);
        }
    }
}
