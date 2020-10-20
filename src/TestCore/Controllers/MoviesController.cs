using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCore.Mappers;
using TestCore.Services;
using TestCore.ViewModels;

namespace TestCore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly ISpecialOperationsMovieService _specialOperationsMovieService;

        public MoviesController(IMoviesService movieService, ISpecialOperationsMovieService specialOperationsMovieService)
        {
            _movieService = movieService;
            _specialOperationsMovieService = specialOperationsMovieService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var data = await _movieService.List();

            var result = data.Select(MovieMapper.Map);
            return View(result);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService.Get(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(MovieMapper.Map(movie));
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Price,Genre,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Create(MovieMapper.Map(movie));
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService.Get(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(MovieMapper.Map(movie));
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Price,Genre,Rating")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _movieService.Update(MovieMapper.Map(movie));
                }
                catch (DbUpdateConcurrencyException)
                {
                    var dbMovie = await _movieService.Get(movie.ID);
                    if (dbMovie == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieService.Get(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(MovieMapper.Map(movie));
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ResetRating(int id)
        {
            await _specialOperationsMovieService.ResetRating(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ResetGenre(int id)
        {
            await _specialOperationsMovieService.ResetGenre(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
