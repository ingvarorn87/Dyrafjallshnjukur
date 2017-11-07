using DAL;
using System;


namespace DemoDAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
        IVideoRepository VideoRepository { get; }
        IGenreRepository GenreRepository { get; }

        int Complete();
    }
}
