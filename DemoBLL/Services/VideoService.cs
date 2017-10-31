using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;

namespace BLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();






        public VideoBO Create(VideoBO vid)
        {
            throw new NotImplementedException();
        }

        public VideoBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public VideoBO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<VideoBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public VideoBO Update(VideoBO vid)
        {
            throw new NotImplementedException();
        }
    }
}
