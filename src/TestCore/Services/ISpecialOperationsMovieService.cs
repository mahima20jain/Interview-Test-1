using System.Threading.Tasks;

namespace TestCore.Services
{
    public interface ISpecialOperationsMovieService
    {
        Task ResetRating(int id);

        Task ResetGenre(int id);
    }
}
