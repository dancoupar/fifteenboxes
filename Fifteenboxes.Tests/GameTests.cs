using FifteenBoxes;

namespace Fifteenboxes.Tests
{
	public class GameTests
	{
		[Fact]
		public void There_are_fifteen_boxes()
		{
			// Arrange/Act
			var sut = new Game(new NullPrizePlacer());

			// Assert
			int count = 0;
			foreach (Box box in sut.Boxes)
			{
				if (box is not null)
				{
					count++;
				}
			}

			Assert.Equal(15, count);
		}

		[Fact]
		public void Boxes_are_arranged_into_five_columns_and_three_rows()
		{
			// Arrange/Act
			var sut = new Game(new NullPrizePlacer());

			// Assert
			Assert.Equal(5, sut.Boxes.GetLength(0));
			Assert.Equal(3, sut.Boxes.GetLength(1));
		}

		[Fact]
		public void Boxes_are_lettered_alphabetically_from_a_to_o()
		{
			// Arrange/Act
			var sut = new Game(new NullPrizePlacer());

			// Assert
			Assert.Equal('A', sut.Boxes[0, 0].Letter);
			Assert.Equal('B', sut.Boxes[1, 0].Letter);
			Assert.Equal('C', sut.Boxes[2, 0].Letter);
			Assert.Equal('D', sut.Boxes[3, 0].Letter);
			Assert.Equal('E', sut.Boxes[4, 0].Letter);

			Assert.Equal('F', sut.Boxes[0, 1].Letter);
			Assert.Equal('G', sut.Boxes[1, 1].Letter);
			Assert.Equal('H', sut.Boxes[2, 1].Letter);
			Assert.Equal('I', sut.Boxes[3, 1].Letter);
			Assert.Equal('J', sut.Boxes[4, 1].Letter);

			Assert.Equal('K', sut.Boxes[0, 2].Letter);
			Assert.Equal('L', sut.Boxes[1, 2].Letter);
			Assert.Equal('M', sut.Boxes[2, 2].Letter);
			Assert.Equal('N', sut.Boxes[3, 2].Letter);
			Assert.Equal('O', sut.Boxes[4, 2].Letter);
		}

		[Fact]
		public void Boxes_can_be_identified_by_letter()
		{
			// Arrange
			var sut = new Game(new NullPrizePlacer());

			// Act/Assert
			Assert.Same(sut.GetBox('A'), sut.Boxes[0, 0]);
			Assert.Same(sut.GetBox('B'), sut.Boxes[1, 0]);
			Assert.Same(sut.GetBox('C'), sut.Boxes[2, 0]);
			Assert.Same(sut.GetBox('D'), sut.Boxes[3, 0]);
			Assert.Same(sut.GetBox('E'), sut.Boxes[4, 0]);

			Assert.Same(sut.GetBox('F'), sut.Boxes[0, 1]);
			Assert.Same(sut.GetBox('G'), sut.Boxes[1, 1]);
			Assert.Same(sut.GetBox('H'), sut.Boxes[2, 1]);
			Assert.Same(sut.GetBox('I'), sut.Boxes[3, 1]);
			Assert.Same(sut.GetBox('J'), sut.Boxes[4, 1]);

			Assert.Same(sut.GetBox('K'), sut.Boxes[0, 2]);
			Assert.Same(sut.GetBox('L'), sut.Boxes[1, 2]);
			Assert.Same(sut.GetBox('M'), sut.Boxes[2, 2]);
			Assert.Same(sut.GetBox('N'), sut.Boxes[3, 2]);
			Assert.Same(sut.GetBox('O'), sut.Boxes[4, 2]);
		}

		[Fact]
		public void All_boxes_are_empty_to_begin_with()
		{
			// Arrange/Act
			var sut = new Game(new NullPrizePlacer());

			// Assert
			foreach (Box box in sut.Boxes)
			{
				Assert.False(box.ContainsPrize());
				Assert.True(box.PrizeCount == 0);
			}
        }
	}
}