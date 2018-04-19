using UnityEngine;
using System.Collections;

public class GridCell : MonoBehaviour
{
	public Transform tile;
	public Transform tileBackground;
	public Transform westWall;
	public Transform southWall;

	public bool SouthWall
	{
		get { return southWall.gameObject.activeSelf; }
		set { southWall.gameObject.SetActive(value); }
	}

	public bool WestWall
	{
		get { return westWall.gameObject.activeSelf; }
		set { westWall.gameObject.SetActive(value); }
	}

	public bool Floor
	{
		get { return tile.gameObject.activeSelf; }
		set
		{
			tile.gameObject.SetActive(value);
			tileBackground.gameObject.SetActive(value);
		}
	}
}
