

using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    class GenreConverter
    {
        internal Genre Convert(GenreBO gen)
        {
            if (gen == null) { return null; }
            return new Genre()
            {
                Id = gen.Id,
                Name = gen.Name
            };
        }

        internal GenreBO Convert(Genre gen)
        {
            if (gen == null) { return null; }
            return new GenreBO()
            {
                Id = gen.Id,
                Name = gen.Name
            };
        }
    }
}
