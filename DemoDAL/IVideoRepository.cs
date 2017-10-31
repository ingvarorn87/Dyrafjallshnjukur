using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IVideoRepository
    {
        Video Create(Video vid);

        List<Video> GetAll();
        Video Get(int Id);

        Video Delete(int Id);
    }
}
