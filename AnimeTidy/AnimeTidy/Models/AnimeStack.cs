namespace AnimeTidy.Models
{
	public class AnimeStack
	{
		public EditType EType
		{ get; set; }

		public Anime EAnime
		{ get; set; }

		public Anime OrgAnime
		{ get; set; }

		public AnimeStack() { }

		public AnimeStack(EditType etype, Anime eanime)
		{
			this.EType = etype;
			this.EAnime = eanime;
		}

		public AnimeStack(EditType etype, Anime eanime, Anime organime)
		{
			this.EType = etype;
			this.EAnime = eanime;
			this.OrgAnime = organime;
		}
	}
}
