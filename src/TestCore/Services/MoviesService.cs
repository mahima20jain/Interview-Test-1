using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCore.Data;
using TestCore.Models;

namespace TestCore.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MovieContext _context;

        public MoviesService(MovieContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> List()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            return movie;
        }

        public async Task<Movie> Create(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            
            return movie;
        }

        public async Task<Movie> Update(Movie movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task Delete(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
