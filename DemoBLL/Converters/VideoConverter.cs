﻿using BLL.BusinessObjects;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
                Genre = vid.Genre,
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
                Genre = vid.Genre,
                Year = vid.Year,
                Available = vid.Available
            };
        }

    }

    
}
