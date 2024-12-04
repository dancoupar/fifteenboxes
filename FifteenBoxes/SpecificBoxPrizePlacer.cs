namespace FifteenBoxes
{
	public class SpecificBoxPrizePlacer(params char[] prizeBoxes) : IPrizePlacer
	{
		private readonly char[] _prizeBoxes = prizeBoxes;

		public void PlacePrizes(Game game)
		{
			foreach (char boxLetter in _prizeBoxes)
			{
				game.GetBox(boxLetter).PlacePrize();
			}
		}
	}
}
