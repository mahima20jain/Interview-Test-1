namespace TestCore.Mappers
{
    public class MovieMapper
    {
        public static ViewModels.Movie Map(Models.Movie data)
        {
            return new ViewModels.Movie
            {
                ID = data.ID,
                Price = data.Price,
                Genre = data.Rating,
                Rating = data.Genre,
                ReleaseDate = data.ReleaseDate,
                Title = data.Title
            };
        }

        public static Models.Movie Map(ViewModels.Movie data)
        {
            return new Models.Movie
            {
                ID = data.ID,
                Price = data.Price,
                Genre = data.Rating,
                Rating = data.Genre,
                ReleaseDate = data.ReleaseDate,
                Title = data.Title
            };
        }
    }
}
