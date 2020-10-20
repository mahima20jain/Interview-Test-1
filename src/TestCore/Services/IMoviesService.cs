using System.Collections.Generic;
using System.Threading.Tasks;
using TestCore.Models;

namespace TestCore.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> List();

        Task<Movie> Get(int id);

        Task<Movie> Create(Movie movie);

        Task<Movie> Update(Movie movie);

        Task Delete(int id);
    }
}
