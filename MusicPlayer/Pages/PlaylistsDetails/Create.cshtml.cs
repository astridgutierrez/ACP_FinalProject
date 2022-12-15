using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPlayer.Data;
using MusicPlayer.Models;

namespace MusicPlayer.Pages.PlaylistsDetails
{
    public class CreateModel : PageModel
    {
        private readonly MusicPlayer.Data.MusicPlayerContext _context;

        public CreateModel(MusicPlayer.Data.MusicPlayerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlaylistDetails PlaylistDetails { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlaylistDetails.Add(PlaylistDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
