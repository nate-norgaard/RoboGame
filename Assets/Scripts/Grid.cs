using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
	public int Rows { get; private set; }
	public int Columns { get; private set; }

	public GridCell[,] GridCells { get; private set; }

	public void Init(int initRows, int initColumns)
	{
		Rows = initRows;
		Columns = initColumns;
		GridCells = new GridCell[Columns + 1, Rows + 1]; // add one for walls on north and east sides
	}

	public GridCell GetCell(Coord2D coord)
	{
		return GridCells[coord.x, coord.y];
	}

	public bool Wall(Coord2D coord, Direction direction)
	{
		Coord2D shift;
		switch (direction)
		{
			case Direction.East:
				shift = new Coord2D(1, 0);
				return GetCell(coord + shift).WestWall;

			case Direction.North:
				shift = new Coord2D(0, 1);
				return GetCell(coord + shift).SouthWall;

			case Direction.West:
				return GetCell(coord).WestWall;

			case Direction.South:
				return GetCell(coord).SouthWall;
		}

		throw new System.Exception("Not reached! Not a cardinal direction!");
	}
}
