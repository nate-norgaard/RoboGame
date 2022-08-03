using UnityEngine;

[System.Serializable]
public struct Coord2d
{
	public int X { get; set; }
	public int Y { get; set; }

	public float Magnitude { get { return Mathf.Sqrt(X * X + Y * Y); } }
	public Vector3 Position { get { return new Vector3(X, 0, Y); } }

	public Coord2d(int x, int y)
	{
		X = x;
		Y = y;
	}

	public override bool Equals(object obj)
	{
		return this == (Coord2d)obj;
	}

	public override int GetHashCode()
	{
		return X * Y;
	}

	public static bool operator ==(Coord2d c1, Coord2d c2)
	{
		return c1.X == c2.X && c1.Y == c2.Y;
	}

	public static bool operator !=(Coord2d c1, Coord2d c2)
	{
		return !(c1 == c2);
	}

	public static Coord2d operator +(Coord2d c1, Coord2d c2)
	{
		return new Coord2d(c1.X + c2.X, c1.Y + c2.Y);
	}

	public static Coord2d operator -(Coord2d c1, Coord2d c2)
	{
		return new Coord2d(c1.X - c2.X, c1.Y - c2.Y);
	}

	public static Coord2d operator *(Coord2d coord, int factor)
	{
		return new Coord2d(coord.X * factor, coord.Y * factor);
	}

	public static Coord2d operator /(Coord2d coord, int divisor)
	{
		return new Coord2d(coord.X / divisor, coord.Y / divisor);
	}
}