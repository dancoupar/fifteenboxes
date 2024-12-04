using FifteenBoxes;

namespace Fifteenboxes.Tests
{
	public class RandomPrizePlacerTests
	{
		[Fact]
		public void One_prize_is_found_if_one_prize_is_placed_randomly_in_a_box()
		{
			// Arrange
			var sut = new RandomBoxPrizePlacer(1);
			var game = new Game(sut);

			// Act
			game.PlacePrizes();

			// Assert
			IEnumerable<Box> boxesWithPrizes = game.Boxes.Cast<Box>().Where(b => b.ContainsPrize());
			IEnumerable<Box> boxesWithoutPrizes = game.Boxes.Cast<Box>().Where(b => !b.ContainsPrize());

			Assert.True(boxesWithPrizes.Count() == 1);
			Assert.True(boxesWithoutPrizes.Count() == 14);
			Assert.Equal(1, boxesWithPrizes.Sum(b => b.PrizeCount));
			Assert.Equal(0, boxesWithoutPrizes.Sum(b => b.PrizeCount));
		}

		[Fact]
		public void Two_prizes_are_found_if_two_prizes_are_placed_randomly_in_two_boxes_box()
		{
			// Arrange
			var sut = new RandomBoxPrizePlacer(2);
			var game = new Game(sut);

			// Act
			game.PlacePrizes();

			// Assert
			IEnumerable<Box> boxesWithPrizes = game.Boxes.Cast<Box>().Where(b => b.ContainsPrize());
			IEnumerable<Box> boxesWithoutPrizes = game.Boxes.Cast<Box>().Where(b => !b.ContainsPrize());

			Assert.True(boxesWithPrizes.Count() == 1 || boxesWithPrizes.Count() == 2);
			Assert.True(boxesWithoutPrizes.Count() == 14 || boxesWithoutPrizes.Count() == 13);
			Assert.Equal(2, boxesWithPrizes.Sum(b => b.PrizeCount));
			Assert.Equal(0, boxesWithoutPrizes.Sum(b => b.PrizeCount));
		}

		[Fact]
		public void Prize_distribution_is_even_with_one_prize()
		{
			// Arrange
			var sut = new RandomBoxPrizePlacer(1);
			var game = new Game(sut);
			var prizeFrequencies = new int[5, 3];
			int iterations = 1000000;

			// Act
			for (int i = 0; i < iterations; i++)
			{
				game.PlacePrizes();

				for (int x = 0; x < prizeFrequencies.GetLength(0); x++)
				{
					for (int y = 0; y < prizeFrequencies.GetLength(1); y++)
					{
						prizeFrequencies[x, y] += game.Boxes[x, y].PrizeCount;
					}
				}

				game.Reset();
			}

			// Assert
			double deviationTollerance = GetDeviationTollerance(game.Boxes.Length, 1, iterations, out float theoreticalMean);

			// There's a 1.5% chance of at least one of these assertions failing
			foreach (int frequency in prizeFrequencies)
			{
				Assert.True(Math.Abs(frequency - theoreticalMean) < deviationTollerance);
			}
		}

		[Fact]
		public void Prize_distribution_is_even_with_two_prizes()
		{
			// Arrange
			var sut = new RandomBoxPrizePlacer(2);
			var game = new Game(sut);
			var prizeFrequencies = new int[5, 3];
			int iterations = 1000000;

			// Act
			for (int i = 0; i < iterations; i++)
			{
				game.PlacePrizes();

				for (int x = 0; x < prizeFrequencies.GetLength(0); x++)
				{
					for (int y = 0; y < prizeFrequencies.GetLength(1); y++)
					{
						prizeFrequencies[x, y] += game.Boxes[x, y].PrizeCount;
					}
				}

				game.Reset();
			}

			// Assert
			double deviationTollerance = GetDeviationTollerance(game.Boxes.Length, 2, iterations, out float theoreticalMean);

			// There's a 1.5% chance of at least one of these assertions failing
			foreach (int frequency in prizeFrequencies)
			{
				Assert.True(Math.Abs(frequency - theoreticalMean) < deviationTollerance);
			}
		}

		/// <summary>
		/// Gets the maximum amount we can expect a given box tally to deviate from the mean if we
		/// want to be 99.9% sure the prize distribution is even. Looking at it differently, any
		/// assertions made based on this figure will fail 0.1% of the time.
		/// </summary>
		/// <param name="numberOfBoxes">
		/// The number of boxes in the game.
		/// </param>
		/// <param name="numberOfPrizes">
		/// The number of prizes placed per iteration.
		/// </param>
		/// <param name="numberOfIterations">
		/// The number of iterations.
		/// </param>
		/// <param name="theoreticalMean">
		/// The mean number of prizes we should expect per box after the specified number of
		/// iterations.
		/// </param>
		/// <returns>
		/// The deviation tollerance for a 99.9% level of confidence.
		/// </returns>
		private static double GetDeviationTollerance(int numberOfBoxes, int numberOfPrizes, int numberOfIterations, out float theoreticalMean)
		{
			// The mean tally of prizes we should expect per box after n iterations
			theoreticalMean = (float)numberOfPrizes / numberOfBoxes * numberOfIterations;

			// The probability of finding a prize in a given box after one iteration
			float probability = (float)numberOfPrizes / numberOfBoxes;

			// The standard deviation based on the two above figures
			double standardDeviation = Math.Sqrt(theoreticalMean * (1 - probability));

			// The z-value corresponding with 99.9% confidence
			const float zValue = 3.291f;

			return standardDeviation * zValue;
		}
	}
}
