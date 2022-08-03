using UnityEngine;
using System.Collections;
using System;

public class GridAgent : MonoBehaviour
{
	public Coord2d GridPosition { get; private set; }
	public Direction4d DirectionFacing { get; private set; }

	private Grid m_grid;
	private bool m_animating;

	public GridAgent()
	{
		m_animating = false;
	}

	public void Initialize(Grid grid, Coord2d gridPosition, Direction4d direction)
	{
		m_grid = grid;
		GridPosition = gridPosition;
		DirectionFacing = direction;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		/*
		if (Input.GetKeyDown(KeyCode.D))
		{
			Turn(LeftRight.Right);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			Turn(LeftRight.Left);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			Move(1);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Move(-1);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			Move(3);
		}
		*/
	}
	
	public int SpacesMovable(int maxSpaces)
	{
		int spacesMovable = 0;
		Direction4d directionMoving = (maxSpaces >= 0) ? DirectionFacing : Direction.Opposite(DirectionFacing);
		Coord2d moveVector = Direction.ToVector(directionMoving);
		Coord2d walkCoord = GridPosition;

		for (; Mathf.Abs(spacesMovable) < Mathf.Abs(maxSpaces); spacesMovable += maxSpaces / Mathf.Abs(maxSpaces))
		{
			if (m_grid.Wall(walkCoord, directionMoving))
				break;

			walkCoord += moveVector;
		}

		return spacesMovable;
	}

	public void Move(int numSpaces)
	{
		if (!m_animating)
		{
			m_animating = true;
			int spacesMovable = SpacesMovable(numSpaces);
			Coord2d moveVector = Direction.ToVector(DirectionFacing);
			StartCoroutine(MoveCoroutine(GridPosition + moveVector * spacesMovable));
		}
	}

	IEnumerator MoveCoroutine(Coord2d destination)
	{
		Vector3 initialPosition = transform.position;
		Vector3 finalPosition = destination.Position;

		float moveSpeed = 1.5f;
		float percent = 0f;

		while (percent < 1f)
		{
			percent += moveSpeed * Time.deltaTime;
			transform.position = Vector3.Lerp(initialPosition, finalPosition, percent);
			yield return null;
		}

		GridPosition = destination;
		m_animating = false;
	}

	public void Turn(LeftRight turnDirection)
	{
		if (!m_animating)
		{
			m_animating = true;
			StartCoroutine(TurnCoroutine(turnDirection));
		}
	}

	IEnumerator TurnCoroutine(LeftRight turnDirection)
	{
		int turnDegrees = Direction.ToDegrees(turnDirection);
		Quaternion initialRotation = transform.rotation;
		Quaternion finalRotation = Quaternion.Euler(initialRotation.eulerAngles + new Vector3(0, turnDegrees, 0));

		int turnSpeed = 2;
		float percent = 0f;

		while (percent < 1f)
		{
			percent += turnSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Lerp(initialRotation, finalRotation, percent);
			yield return null;
		}

		DirectionFacing = Direction.Turn(DirectionFacing, turnDirection);
		m_animating = false;
	}
}
