using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication3.Models.Firma> Firma { get; set; }
        public DbSet<WebApplication3.Models.Garaj> Garaj { get; set; }
        public DbSet<WebApplication3.Models.Otobus> Otobus { get; set; }
        public DbSet<WebApplication3.Models.Yolcu> Yolcu { get; set; }
    }
}
