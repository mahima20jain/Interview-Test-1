using Microsoft.EntityFrameworkCore;
using TestCore.Models;

namespace TestCore.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (
            DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
