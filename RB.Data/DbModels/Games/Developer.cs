using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RB.Common.Constants;

namespace RB.Data.DbModels.Games
{
    public class Developer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(GameConstants.MinDeveloperName)]
        [MaxLength(GameConstants.MaxDeveloperName)]
        public string Name { get; set; }

        [Required]
        [MinLength(GameConstants.MinOriginCity)]
        [MaxLength(GameConstants.MaxOriginCity)]
        public string OriginCity { get; set; }

        [Required]
        [MinLength(GameConstants.MinOriginCountry)]
        [MaxLength(GameConstants.MaxOriginCountry)]
        public string OriginCountry { get; set; }

        [Range(GameConstants.MinOverhaulRating, GameConstants.MaxOverhaulRating)]
        public float OverallRating { get; set; }

        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}