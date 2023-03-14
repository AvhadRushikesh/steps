﻿using PropertyChanged;
using SQLite;

namespace steps.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("Movies")]
    public class Movies
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Rating { get; set; }

        public string ImageUrl { get; set; }

        public bool isFavorite { get; set; }
    }
}