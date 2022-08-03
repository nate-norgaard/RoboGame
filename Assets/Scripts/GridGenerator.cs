using UnityEngine;
using System.Collections;
using System;

public class GridGenerator : MonoBehaviour
{
	public Grid gridPrefab;
	public int rows = 1;
	public int columns = 1;
	public int seed = 0;
	public float percentWalls = 0.5f;

	public GridCell gridCellPrefab;

	public void Awake()
	{
		//GenerateGrid();
	}

	public Grid GenerateGrid()
	{
		string gridName = "Grid";
		if (transform.FindChild(gridName))
		{
			DestroyImmediate(transform.FindChild(gridName).gameObject);
		}

		Grid grid = Instantiate(gridPrefab, transform.position, transform.rotation) as Grid;
		grid.name = gridName;
		grid.Initialize(rows, columns);
		grid.transform.parent = transform;

		System.Random random = new System.Random(seed);

		for (int c = 0; c <= columns; c++)
		{
			for (int r = 0; r <= rows; r++)
			{
				GridCell gridCell = Instantiate(gridCellPrefab, grid.transform.position + new Vector3(c, 0, r), grid.transform.rotation) as GridCell;
				grid.GridCells[c, r] = gridCell;
				gridCell.transform.parent = grid.transform;

				if (random.NextDouble() > percentWalls)
					gridCell.SouthWall = false;
				if (random.NextDouble() > percentWalls)
					gridCell.WestWall = false;
			}
		}

		for (int c = 0; c <= columns; c++)
		{
			GridCell gridCell = grid.GridCells[c, rows];
			gridCell.WestWall = false;
			gridCell.Floor = false;
		}

		for (int r = 0; r <= rows; r++)
		{
			GridCell gridCell = grid.GridCells[columns, r];
			gridCell.SouthWall = false;
			gridCell.Floor = false;
		}

		return grid;
	}
}
