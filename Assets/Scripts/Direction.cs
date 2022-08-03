using UnityEngine;
using System.Collections;
using System;

public enum Direction4d
{
	East = 0,
	North = 1,
	West = 2,
	South = 3
}

public enum LeftRight
{
	Left,
	Right
}

static class Direction
{
	private const Direction4d east = Direction4d.East;
	private const Direction4d north = Direction4d.North;
	private const Direction4d west = Direction4d.West;
	private const Direction4d south = Direction4d.South;
	private const LeftRight left = LeftRight.Left;
	private const LeftRight right = LeftRight.Right;

	public static Coord2d ToVector(Direction4d direction)
	{
		switch (direction)
		{
			case east:
				return new Coord2d(1, 0);
			case north:
				return new Coord2d(0, 1);
			case west:
				return new Coord2d(-1, 0);
			case south:
				return new Coord2d(0, -1);
			default:
				throw new Exception("Weird Direction4d in Direction.ToVector");
		}
	}

	public static Direction4d Turn(Direction4d direction, LeftRight lr)
	{
		if (lr == left)
		{
			switch(direction)
			{
				case east:
					return north;
				case north:
					return west;
				case west:
					return south;
				case south:
					return east;
				default:
					throw new Exception("Weird Direction4d in Direction.Turn");
			}
		}
		else
		{
			switch (direction)
			{
				case east:
					return south;
				case south:
					return west;
				case west:
					return north;
				case north:
					return east;
				default:
					throw new Exception("Weird Direction4d in Direction.Turn");
			}
		}
	}

	public static int ToDegrees(Direction4d direction)
	{
		switch(direction)
		{
			case east:
				return 90;
			case north:
				return 0;
			case west:
				return 270;
			case south:
				return 180;
			default:
				throw new Exception("Weird Direction4d in Direction.ToDegrees");
		}
	}

	public static int ToDegrees(LeftRight lr)
	{
		if (lr == left)
		{
			return -90;
		}
		else
		{
			return 90;
		}
	}

	public static int Clamp(int degrees)
	{
		return degrees % 360;
	}

	public static Direction4d Opposite(Direction4d direction)
	{
		switch (direction)
		{
			case east:
				return west;
			case north:
				return south;
			case west:
				return east;
			case south:
				return north;
			default:
				throw new Exception("Weird Direction4d in Direction.ToDegrees");
		}
	}
}
