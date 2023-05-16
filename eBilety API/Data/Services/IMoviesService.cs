using eBilety.Data.Base;
using eBilety.Data.ViewModels;
using eBilety.Models;

namespace eBilety.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> AddNewMovieAsync(NewMovieVM data);
        Task<Movie> UpdateMovieAsync(NewMovieVM data);
    }
}
