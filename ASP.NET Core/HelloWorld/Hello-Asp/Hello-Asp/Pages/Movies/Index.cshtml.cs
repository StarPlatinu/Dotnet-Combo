using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hello_Asp.Data;
using Hello_Asp.Models;

namespace Hello_Asp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Hello_Asp.Data.RazorPagesMovieContext _context;

        public IndexModel(Hello_Asp.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
