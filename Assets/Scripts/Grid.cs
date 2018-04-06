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
}
