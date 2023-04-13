using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.DTO
{
    public class MoviesDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public string imageUrl { get; set; }
        public bool isFavorite { get; set; }
    }
}
