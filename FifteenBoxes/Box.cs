namespace FifteenBoxes
{
	public class Box(char letter)
	{
		public int PrizeCount { get; private set; } = 0;

		public char Letter { get; } = letter;		

		public void PlacePrize()
		{
			this.PrizeCount++;
		}

		public void Empty()
		{
			this.PrizeCount = 0;
		}

		public bool ContainsPrize()
		{
			return this.PrizeCount > 0;
		}
	}
}
