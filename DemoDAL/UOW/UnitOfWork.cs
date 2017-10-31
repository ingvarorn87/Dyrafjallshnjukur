using System;
using DAL;
using DemoDAL.Context;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Repositories;

namespace DemoDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        // public ICustomerRepository CustomerRepository { get; internal set; }
        private VideoAppContext context;
        private EASVContext easvContext;
        private static DbContextOptions<EASVContext> optionsStatic;

        public IVideoRepository VideoReposotory { get; internal set; }

        public UnitOfWork()
        {
            context = new VideoAppContext();
            context.Database.EnsureCreated();
            VideoReposotory = new VideoRepo(context);
        }

    public UnitOfWork(DbOptions opt)
        {
             if(opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString)){
                optionsStatic = new DbContextOptionsBuilder<EASVContext>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;
                easvContext = new EASVContext(optionsStatic);
            }
            else{
                var options = new DbContextOptionsBuilder<EASVContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
                easvContext = new EASVContext(options);
            }

            //CustomerRepository = new CustomerRepository(context);
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
