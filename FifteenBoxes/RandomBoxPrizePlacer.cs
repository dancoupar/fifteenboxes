namespace FifteenBoxes
{
	public class RandomBoxPrizePlacer(int numberOfPrizes) : IPrizePlacer
	{
		// We don't need secure random numbers, only a smooth distribution
		private readonly Random _pseudoRandom = new();
		private readonly int _numberOfPrizes = numberOfPrizes;

		public void PlacePrizes(Game game)
		{
			for (int i = 0; i < _numberOfPrizes; i++)
			{
				game.Boxes[_pseudoRandom.Next(0, 5), _pseudoRandom.Next(0, 3)].PlacePrize();
			}
		}
	}
}
