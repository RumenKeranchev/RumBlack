namespace RB.Data.DbModels.Social
{
	public class SocialComment : CommentsBase
	{
		public int Likes { get; set; }

		public int Dislikes { get; set; }
	}
}