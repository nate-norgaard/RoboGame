using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
	public int Rows;
	public int Columns;
	public GridCell[,] GridCells;

	private int XSize { get { return Columns + 1; } }
	private int YSize { get { return Rows + 1; } }

	public void Initialize(int initRows, int initColumns)
	{
		Rows = initRows;
		Columns = initColumns;
		GridCells = new GridCell[XSize, YSize]; // add one for walls on north and east sides
	}

	public bool TryGetCell(Coord2d coord, out GridCell gridCell)
	{
		gridCell = null;
		if (coord.X >= 0 && coord.X < XSize
			&& coord.Y >= 0 && coord.Y < YSize)
		{
			gridCell = GetCell(coord);
			return true;
		}
		else
		{
			return false;
		}
	}

	public GridCell GetCell(Coord2d coord)
	{
		return GridCells[coord.X, coord.Y];
	}

	public GridCell GetCell(Coord2d coord, Direction4d direction)
	{
		Coord2d directionVector = Direction.ToVector(direction);
		return GetCell(coord + directionVector);
	}

	public bool Wall(Coord2d coord, Direction4d direction)
	{
		Coord2d shift;
		switch (direction)
		{
			case Direction4d.East:
				shift = new Coord2d(1, 0);
				return GetCell(coord + shift).WestWall;

			case Direction4d.North:
				shift = new Coord2d(0, 1);
				return GetCell(coord + shift).SouthWall;

			case Direction4d.West:
				return GetCell(coord).WestWall;

			case Direction4d.South:
				return GetCell(coord).SouthWall;
		}

		throw new System.Exception("Not reached! Not a cardinal direction!");
	}

	public Vector2 Point(Coord2d coord)
	{
		GridCell cell = GetCell(coord);
		return new Vector2(cell.transform.position.x, cell.transform.position.y);
	}
}
