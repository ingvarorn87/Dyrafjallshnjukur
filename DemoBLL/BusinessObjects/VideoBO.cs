using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string VideoName { get; set; }

        public int GenreId { get; set; }
        public GenreBO Genre { get; set; }

        public int Year { get; set; }
        public bool Available { get; set; }
    }
}
