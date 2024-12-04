using FifteenBoxes;

namespace Fifteenboxes.Tests
{
	public class ControlledPrizePlacerTests
	{
		[Theory]
		[InlineData('A')]
		[InlineData('B')]
		[InlineData('C')]
		[InlineData('D')]
		[InlineData('E')]
		[InlineData('F')]
		[InlineData('G')]
		[InlineData('H')]
		[InlineData('I')]
		[InlineData('J')]
		[InlineData('K')]
		[InlineData('L')]
		[InlineData('M')]
		[InlineData('N')]
		[InlineData('O')]
		public void One_prize_is_found_if_one_prize_is_placed_in_a_specific_box(char letter)
		{
			// Arrange
			var sut = new SpecificBoxPrizePlacer(letter);
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
			Assert.Equal(letter, boxesWithPrizes.Single().Letter);
		}

		[Theory]
		[InlineData('A', 'B')]
		[InlineData('C', 'E')]
		[InlineData('F', 'I')]
		[InlineData('J', 'N')]
		[InlineData('A', 'O')]
		public void Two_prizes_are_found_if_two_prizes_are_placed_in_different_boxes(char first, char second)
		{
			// Arrange
			var sut = new SpecificBoxPrizePlacer(first, second);
			var game = new Game(sut);

			// Act
			game.PlacePrizes();

			// Assert
			IEnumerable<Box> boxesWithPrizes = game.Boxes.Cast<Box>().Where(b => b.ContainsPrize());
			IEnumerable<Box> boxesWithoutPrizes = game.Boxes.Cast<Box>().Where(b => !b.ContainsPrize());

			Assert.True(boxesWithPrizes.Count() == 2);
			Assert.True(boxesWithoutPrizes.Count() == 13);
			Assert.Equal(2, boxesWithPrizes.Sum(b => b.PrizeCount));
			Assert.Equal(0, boxesWithoutPrizes.Sum(b => b.PrizeCount));
			Assert.Contains(first, boxesWithPrizes.Select(b => b.Letter));
			Assert.Contains(second, boxesWithPrizes.Select(b => b.Letter));
		}

		[Theory]
		[InlineData('A')]
		[InlineData('H')]
		[InlineData('O')]
		public void Two_prizes_are_found_if_two_prizes_are_placed_in_the_same_box(char letter)
		{
			// Arrange
			var sut = new SpecificBoxPrizePlacer(letter, letter);
			var game = new Game(sut);

			// Act
			game.PlacePrizes();

			// Assert
			IEnumerable<Box> boxesWithPrizes = game.Boxes.Cast<Box>().Where(b => b.ContainsPrize());
			IEnumerable<Box> boxesWithoutPrizes = game.Boxes.Cast<Box>().Where(b => !b.ContainsPrize());

			Assert.True(boxesWithPrizes.Count() == 1);
			Assert.True(boxesWithoutPrizes.Count() == 14);
			Assert.Equal(2, boxesWithPrizes.Single().PrizeCount);
			Assert.Equal(0, boxesWithoutPrizes.Sum(b => b.PrizeCount));
		}
	}
}
