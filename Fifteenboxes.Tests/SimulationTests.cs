using FifteenBoxes;

namespace Fifteenboxes.Tests
{
	public class SimulationTests
    {
		[Fact]
		public void A_single_prize_in_box_a_results_in_a_draw()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('A'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_b_results_in_andrew_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('B'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(1, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_c_results_in_andrew_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('C'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(1, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_d_results_in_andrew_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('D'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(1, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_e_results_in_andrew_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('E'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(1, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_f_results_in_barbara_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('F'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(1, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_g_results_in_barbara_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('G'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(1, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_h_results_in_a_draw()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('H'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_i_results_in_andrew_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('I'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(1, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_j_results_in_andrew_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('J'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(1, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_k_results_in_barbara_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('K'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(1, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_l_results_in_barbara_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('L'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(1, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_m_results_in_barbara_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('M'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(1, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_n_results_in_barbara_winning()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('N'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(1, sut.BarbaraWinCount);
		}

		[Fact]
		public void A_single_prize_in_box_o_results_in_a_draw()
		{
			// Arrange
			var sut = new Simulation(new SpecificBoxPrizePlacer('O'));

			// Act
			sut.Run(1);

			// Assert
			Assert.Equal(0, sut.AndrewWinCount);
			Assert.Equal(0, sut.BarbaraWinCount);
		}

		[Fact]
		public void Andrew_has_a_higher_chance_of_winning_when_two_prizes_are_placed()
		{
			// Arrange
			var boxes = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };			

			int andrewWinScenarios = 0;
			int barbaraWinScenarios = 0;
			
			for (int i = 0; i < boxes.Length; i++)
			{
				for (int j = i; j < boxes.Length; j++)
				{
					var sut = new Simulation(new SpecificBoxPrizePlacer(boxes[i], boxes[j]));
					sut.Run(1);

					andrewWinScenarios += sut.AndrewWinCount;
					barbaraWinScenarios += sut.BarbaraWinCount;
				}
			}

			// Assert
			// 49 vs 45 (and 26 draws, making 120 distinct scenarios)
			Assert.True(andrewWinScenarios > barbaraWinScenarios);
		}

		[Fact]
		public void Andrew_wins_more_often_when_two_prizes_are_placed()
		{
			// Arrange
			var sut = new Simulation(new RandomBoxPrizePlacer(2));

			// Act (10 million iterations)
			sut.Run(10000000);

			// Assert
			// The ratio between Andrew's wins to Barbara's is about 1.09, which is 49/45
			Assert.True(sut.AndrewWinCount > sut.BarbaraWinCount);
		}
	}
}
