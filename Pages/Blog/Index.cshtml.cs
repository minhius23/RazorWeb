using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Razor09.Models;


namespace Razor09.Pages_Blog
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Razor09.Models.MyBlogContext _context;

        public IndexModel(Razor09.Models.MyBlogContext context)
        {
            _context = context;
        
        }
        public const int Items_Per_Page = 10;
        [BindProperty(SupportsGet =true,Name = "p")]
        public int currentPage{set;get;}
        public int countPages{set;get;}

        public IList<Article> Article { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            int totalArticle = await _context.articles.CountAsync();
            countPages = (int)Math.Ceiling((double)totalArticle/Items_Per_Page);
            if(currentPage <1)
            currentPage = 1;
            if(currentPage > countPages)
            currentPage = countPages;
            // Article = await _context.articles.ToListAsync();
            var qr = (from a in _context.articles
                     orderby a.Created descending
                     select a).Skip((currentPage -1) *10)
                     .Take(Items_Per_Page);
            if (!searchString.IsNullOrEmpty())
            {
                Article = qr.Where(a => a.Title.Contains(searchString)).ToList();
            }
            else
            {
                Article = await qr.ToListAsync();
            }

        }
    }
}
