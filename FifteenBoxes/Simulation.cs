namespace FifteenBoxes
{
	public class Simulation(IPrizePlacer prizePlacer)
	{
		private readonly Game _game = new (prizePlacer);

		public int AndrewWinCount { get; private set; } = 0;

		public int BarbaraWinCount { get; private set; } = 0;

		public void Run(int iterations)
        {
			for (int i = 0; i < iterations; i++)
            {
				bool gameOver = false;
				bool andrewWins = false;
				bool barbaraWins = false;

				_game.Reset();
				_game.PlacePrizes();                

				do
				{
					_game.OpenNextBoxes();

					if (_game.HasAndrewFoundPrize())
					{
						if (!_game.HasBarbaraFoundPrize())
						{
							andrewWins = true;
						}

						gameOver = true;
					}

					if (_game.HasBarbaraFoundPrize())
					{
						if (!_game.HasAndrewFoundPrize())
						{
							barbaraWins = true;
						}

						gameOver = true;
					}

				} while (!gameOver);

				if (andrewWins)
				{
					this.AndrewWinCount++;
				}

				if (barbaraWins)
				{
					this.BarbaraWinCount++;
				}
			}
        }
    }
}
