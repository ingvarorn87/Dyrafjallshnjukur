using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;


namespace DAL.Repositories
{
    class GenreRepo : IGenreRepository
    {
        VideoAppContext context;

        public GenreRepo(VideoAppContext context)
        {
            this.context = context;
        }

        public Genre Create(Genre gen)
        {
            this.context.Genres.Add(gen);

            return gen;
        }

        public Genre Delete(int Id)
        {
            var genre = Get(Id);
            this.context.Genres.Remove(genre);
            return genre;
        }

        public Genre Get(int Id)
        {
            return this.context.Genres.FirstOrDefault(g => g.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return this.context.Genres.ToList();
        }

    }
}
