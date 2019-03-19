using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;
using RB.Common.DbCategoriesFlags;

namespace RB.Data.DbModels.Music
{
    public class Band
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(MusicConstants.BandNameMinLength)]
        [MaxLength(MusicConstants.BandNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public MusicGenres Genre { get; set; }

        public IEnumerable<Album> Albums { get; set; } = new List<Album>();

        public IEnumerable<BandConcert> Concerts { get; set; } = new List<BandConcert>();
    }
}