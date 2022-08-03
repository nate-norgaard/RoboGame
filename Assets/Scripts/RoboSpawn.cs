using UnityEngine;
using System.Collections;

public class RoboSpawn : MonoBehaviour
{
	public Grid grid;
	public Coord2d gridPosition;
	public Direction4d direction;

	public void Initialize()
	{
		//grid = _grid;
	}

	public GridAgent Spawn(GridAgent gridAgentPrefab)
	{
		GridAgent gridAgent = GameObject.Instantiate(gridAgentPrefab);
		gridAgent.Initialize(grid, gridPosition, direction);
		return gridAgent;
	}
}
