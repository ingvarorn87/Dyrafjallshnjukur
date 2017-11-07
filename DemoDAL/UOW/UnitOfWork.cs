using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Repositories;


namespace DemoDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        // public ICustomerRepository CustomerRepository { get; internal set; }
        public IVideoRepository VideoRepository { get; internal set; }
        public IGenreRepository GenreRepository { get; internal set; }
        private VideoAppContext context;

        public UnitOfWork()
        {
            context = new VideoAppContext();
            context.Database.EnsureCreated();
            GenreRepository = new GenreRepo(context);
            VideoRepository = new VideoRepo(context);
        }
        

        public int Complete()
		{
			//The number of objects written to the underlying database.
			return context.SaveChanges();
		}

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
