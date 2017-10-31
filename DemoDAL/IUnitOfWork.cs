using System;
namespace DemoDAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }
        IVideoReposotory VideoReposotory { get; }
       
        int Complete();
    }
}
