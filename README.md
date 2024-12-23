# 15 Boxes

I coded this after becoming a bit obsessed with a puzzle that came up on my news feed: https://www.theguardian.com/science/2024/sep/30/did-you-solve-it-the-box-problem-that-baffled-the-boffins

The puzzle describes a scenario where two players, Andrew and Barbara, both open boxes in which they hope to find prizes that have been randomly placed. The boxes are arranged in a grid. Andrew opens boxes row by row and Barbara, column by column. It's easy enough to intuitively understand why both Andrew and Barbara have an equal chance of finding a prize first when a prize is randomly placed. What really messes with your head is why this is not also the case with two prizes.

Having read the solution, there was a part of me that remained unconvinced and so I coded this to test it out. Of course, it's correct; out of all the possible combinations of two prizes in boxes, there are more scenarios where Andrew wins than there are where Barbara wins.

Normally having coded a solution to a particular problem, you naturally develop an intimiate understanding of it. However, what's really interesting in this case is even having coded it, being honest, I'm still no closer to intuitively understanding why it's different when there are two prizes vs one.

The code that's of most interest are the final two `SimulationTests`. These test the purported solution in two ways:

1) By exhaustively running through every possible scenario in which two prizes are placed (i.e. A,A; A,B; A,C etc.) and playing out each scenario according to the game's rules, counting the number of scenarios where Andrew wins vs. the number of scnearios where Barbara wins.
2) By running a simulation millions of times in which two prizes are randomly placed. The number of times Andrew wins vs. the number of times Barbara wins is tallied and compared at the end. This method is reliant on the random distribution of prizes being even, so there are also tests to assert this.

