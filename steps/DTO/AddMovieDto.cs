using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace steps.DTO
{
    public class AddMovieDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Rating { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFavorite { get; set; }
    }
}
