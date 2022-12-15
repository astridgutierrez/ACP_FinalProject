using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;

namespace MusicPlayer.Pages.PlaylistsDetails
{
    public class DetailsModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public DetailsModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

      public PlaylistDetails PlaylistDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlaylistDetails == null)
            {
                return NotFound();
            }

            var playlistdetails = await _context.PlaylistDetails.FirstOrDefaultAsync(m => m.PlaylistDetailsId == id);
            if (playlistdetails == null)
            {
                return NotFound();
            }
            else 
            {
                PlaylistDetails = playlistdetails;
            }
            return Page();
        }
    }
}
