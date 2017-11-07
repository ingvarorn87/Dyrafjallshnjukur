using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        GenreConverter conv = new GenreConverter();
        private DALFacade facade;

        public GenreService(DALFacade facade)
        {
            this.facade = facade;
        }

        public GenreBO Create(GenreBO gen)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGen = uow.GenreRepository.Create(conv.Convert(gen));
                uow.Complete();
                return conv.Convert(newGen);
            }
        }

        public GenreBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newGen = uow.GenreRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newGen);
            }
        }

        public GenreBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {

                return conv.Convert(uow.GenreRepository.Get(Id));
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.GenreRepository.GetAll();
                return uow.GenreRepository.GetAll().Select(g => conv.Convert(g)).ToList();
            }
        }

        public GenreBO Update(GenreBO genre)
        {
            using (var uow = facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Get(genre.Id);
                if (genreEntity == null)
                {
                    throw new InvalidOperationException("Genre not found");
                }
                genreEntity.Name = genre.Name;
                uow.Complete();
                return conv.Convert(genreEntity);

            }
        }


    }
}
