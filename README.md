# FSharp-Game-of-Life-Colours

Extended Game of Life with 4 colours for live cells

Rules:

Any live cell with fewer than two live neighbours dies (Underpopulation).
Any live cell with more than three live neighbours dies (Overpopulation).
Any live cell with two or three live neighbours lives, unchanged, to the next generation.
Any dead cell with exactly three live neighbours will come to life.

Extended Rules:

Live cells can be one of four colours -> Red, Green, Blue and Yellow
When a dead cell comes to life, it's colour is determined by the three neighbouring cells.
	If the cells are different colours, the new live cell is the missing colour from the list.
	If any colour has two or all three then the new living cell joins that colour's population.
