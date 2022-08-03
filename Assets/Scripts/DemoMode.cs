using UnityEngine;
using System.Collections;

public class DemoMode : MonoBehaviour
{
	public Grid grid;
	public GridGenerator gridGenerator;
	public GridAgent playerRoboPrefab;
	public RoboSpawn roboSpawn;
	public PlayerRoboController playerRoboController;

	void Awake ()
	{
		grid = gridGenerator.GenerateGrid();
		roboSpawn.grid = grid;
		GridAgent playerGridAgent = roboSpawn.Spawn(playerRoboPrefab);
		playerRoboController.robo = playerGridAgent;
	}
}
