namespace FifteenBoxes
{
	public class Game
	{		
		private readonly IPrizePlacer _prizePlacer;
		private (int, int) _andrewCurrentBox;
		private (int, int) _barbaraCurrentBox;

		public Game(IPrizePlacer prizePlacer)
		{
			_prizePlacer = prizePlacer ?? throw new ArgumentNullException(nameof(prizePlacer));

			this.Boxes = new Box[5, 3];

			this.Boxes[0, 0] = new Box('A');
			this.Boxes[1, 0] = new Box('B');
			this.Boxes[2, 0] = new Box('C');
			this.Boxes[3, 0] = new Box('D');
			this.Boxes[4, 0] = new Box('E');

			this.Boxes[0, 1] = new Box('F');
			this.Boxes[1, 1] = new Box('G');
			this.Boxes[2, 1] = new Box('H');
			this.Boxes[3, 1] = new Box('I');
			this.Boxes[4, 1] = new Box('J');

			this.Boxes[0, 2] = new Box('K');
			this.Boxes[1, 2] = new Box('L');
			this.Boxes[2, 2] = new Box('M');
			this.Boxes[3, 2] = new Box('N');
			this.Boxes[4, 2] = new Box('O');

			this.Reset();
		}

		public Box[,] Boxes { get; }

		public Box GetBox(char letter)
		{
			return this.Boxes.Cast<Box>().Single(b => b.Letter == letter);
		}

		public void PlacePrizes()
		{
			_prizePlacer.PlacePrizes(this);
		}

		public void OpenNextBoxes()
		{
			this.AndrewOpenNextBox();
			this.BarbaraOpenNextBox();
		}

		public void Reset()
		{
			foreach (Box box in this.Boxes)
			{
				box.Empty();
			}

			_andrewCurrentBox = (-1, 0);
			_barbaraCurrentBox = (0, -1);
		}

		private void AndrewOpenNextBox()
		{
			if (_andrewCurrentBox.Item1 < 4)
			{
				_andrewCurrentBox = (_andrewCurrentBox.Item1 + 1, _andrewCurrentBox.Item2);
			}
			else
			{
				// New row
				_andrewCurrentBox = (0, _andrewCurrentBox.Item2 + 1);
			}
		}

		private void BarbaraOpenNextBox()
		{
			if (_barbaraCurrentBox.Item2 < 2)
			{
				_barbaraCurrentBox = (_barbaraCurrentBox.Item1, _barbaraCurrentBox.Item2 + 1);
			}
			else
			{
				// New column
				_barbaraCurrentBox = (_barbaraCurrentBox.Item1 + 1, 0);
			}
		}

		public bool HasAndrewFoundPrize()
		{
			return this.Boxes[_andrewCurrentBox.Item1, _andrewCurrentBox.Item2].ContainsPrize();
		}

		public bool HasBarbaraFoundPrize()
		{
			return this.Boxes[_barbaraCurrentBox.Item1, _barbaraCurrentBox.Item2].ContainsPrize();
		}
	}
}
