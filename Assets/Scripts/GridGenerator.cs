using UnityEngine;
using System.Collections;
using System;

public class GridGenerator : MonoBehaviour
{
	public Grid gridPrefab;
	public int rows = 1;
	public int columns = 1;

	public GridCell gridCellPrefab;

	public void Awake()
	{
		GenerateGrid();
	}

	public void GenerateGrid()
	{
		string gridName = "Grid";
		if (transform.FindChild(gridName))
		{
			DestroyImmediate(transform.FindChild(gridName).gameObject);
		}

		Grid grid = Instantiate(gridPrefab, transform.position, transform.rotation) as Grid;
		grid.name = gridName;
		grid.Init(rows, columns);
		grid.transform.parent = transform;

		for (int c = 0; c <= columns; c++)
		{
			for (int r = 0; r <= rows; r++)
			{
				GridCell gridCell = Instantiate(gridCellPrefab, grid.transform.position + new Vector3(c, 0, r), grid.transform.rotation) as GridCell;
				grid.GridCells[c, r] = gridCell;
				gridCell.transform.parent = grid.transform;
			}
		}

		for (int c = 0; c <= columns; c++)
		{
			GridCell gridCell = grid.GridCells[c, rows];
			gridCell.westWall.gameObject.SetActive(false);
			gridCell.tile.gameObject.SetActive(false);
		}

		for (int r = 0; r <= rows; r++)
		{
			GridCell gridCell = grid.GridCells[columns, r];
			gridCell.southWall.gameObject.SetActive(false);
			gridCell.tile.gameObject.SetActive(false);
		}
	}
}
