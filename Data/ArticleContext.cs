using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor09.Pages;

    public class ArticleContext : DbContext
    {
        public ArticleContext (DbContextOptions<ArticleContext> options)
            : base(options)
        {
        }

        public DbSet<Razor09.Pages.Article> Article { get; set; } = default!;
    }
