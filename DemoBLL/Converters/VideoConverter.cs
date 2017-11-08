using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            if(vid == null) { return null; }
            return new Video()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                GenreId = vid.GenreId,
                Year = vid.Year,
                Available = vid.Available
            };

        }

        internal VideoBO Convert(Video vid)
        {
            if (vid == null) { return null; }
            return new VideoBO()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                GenreId = vid.GenreId,
                Genre = new GenreConverter().Convert(vid.Genre),
                Year = vid.Year,
                Available = vid.Available
            };
        }

    }

    
}
