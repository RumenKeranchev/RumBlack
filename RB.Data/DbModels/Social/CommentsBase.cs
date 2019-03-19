using System;
using System.ComponentModel.DataAnnotations;

namespace RB.Data.DbModels.Social
{
    public abstract class CommentsBase
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

	    public string UserId { get; set; }

	    public User User { get; set; }

	    public double Rating { get; set; }
	}
}