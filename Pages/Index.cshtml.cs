using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using Razor09.Models;

namespace Razor09.Pages;


public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext _dbContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        var posts = (from p in _dbContext.articles
                    orderby p.Created descending
                    select p).ToList();
        ViewData["posts"] = posts;
    }                
}
