﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Video
    {
        public string VideoName { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int Year { get; set; }
        public int Id { get; set; }
        public bool Available { get; set; }
    }
}
