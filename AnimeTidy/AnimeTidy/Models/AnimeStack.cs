namespace AnimeTidy.Models
{
	public class AnimeStack
	{
		public EditType EType
		{ get; set; }

		public Anime EAnime
		{ get; set; }

		public AnimeStack() { }

		public AnimeStack(EditType etype, Anime eanime)
		{
			this.EType = etype;
			this.EAnime = eanime;
		}
	}
}
