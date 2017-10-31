using DAL;
using System;
namespace DemoDAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
        IVideoRepository VideoReposotory { get; }
       
        int Complete();
    }
}
