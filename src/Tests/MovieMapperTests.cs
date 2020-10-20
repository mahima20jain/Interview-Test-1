using System;
using TestCore.Mappers;
using Xunit;
namespace Tests
{
    public class MovieMapperTests
    {
        [Fact]
        public void Should_map_title_correct()
        {
            var movie = new TestCore.Models.Movie { Title = "Ghost busters" };

            var result = MovieMapper.Map(movie);

            Assert.Equal(movie.Title, result.Title);
        }

        [Fact]
        public void Should_map_genre_correct()
        {
            var movie = new TestCore.Models.Movie { Genre = "Comedy" };

            var result = MovieMapper.Map(movie);

            Assert.Equal(movie.Genre, result.Genre);
        }

        [Fact]
        public void Should_map_id_correct()
        {
            var movie = new TestCore.Models.Movie { ID = 123 };

            var result = MovieMapper.Map(movie);

            Assert.Equal(movie.ID, result.ID);
        }

        [Fact]
        public void Should_map_price_correct()
        {
            var movie = new TestCore.Models.Movie { Price = 100.01m };

            var result = MovieMapper.Map(movie);

            Assert.Equal(movie.Price, result.Price);
        }

        [Fact]
        public void Should_map_rating_correct()
        {
            var movie = new TestCore.Models.Movie { Rating = "OK" };

            var result = MovieMapper.Map(movie);

            Assert.Equal(movie.Rating, result.Rating);
        }

        [Fact]
        public void Should_map_release_date_correct()
        {
            var movie = new TestCore.Models.Movie {ReleaseDate = DateTime.Parse("2020-10-19")};

            var result = MovieMapper.Map(movie);

            Assert.Equal(movie.ReleaseDate, result.ReleaseDate);
        }
    }
}
