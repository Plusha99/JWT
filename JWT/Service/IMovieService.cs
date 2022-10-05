using JWT.Models;

namespace JWT.Service
{
    public interface IMovieService
    {

        public Movie Create(Movie movie);
        public Movie Update(Movie movie);
        public List<Movie> List();
        public Movie Get(int id);
        public bool Delete(int id);

    }
}
