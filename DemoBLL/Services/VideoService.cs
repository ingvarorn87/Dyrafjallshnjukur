using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using DAL;
using System.Linq;

namespace BLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();

        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }
                
        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(conv.Convert(vid));
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoEntity = uow.VideoRepository.Get(Id);
                videoEntity.Genre = uow.GenreRepository.Get(videoEntity.GenreId);
                return conv.Convert(videoEntity);
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.VideoRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(v => conv.Convert(v)).ToList();
            }
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.Get(vid.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                videoFromDb.VideoName = vid.VideoName;
                videoFromDb.GenreId = vid.GenreId;

                uow.Complete();
                videoFromDb.Genre = uow.GenreRepository.Get(videoFromDb.GenreId);
                return conv.Convert(videoFromDb);
            }
        }
    }
}
