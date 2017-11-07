using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IGenreRepository
    {
        Genre Create(Genre gen);

        List<Genre> GetAll();
        Genre Get(int Id);



        Genre Delete(int Id);

    }
}
