[System.Serializable]
public struct Coord2D
{
	public int x;
	public int y;

	public Coord2D(int _x, int _y)
	{
		x = _x;
		y = _y;
	}

	public override bool Equals(object obj)
	{
		return this == (Coord2D)obj;
	}

	public override int GetHashCode()
	{
		return x * y;
	}

	public static bool operator ==(Coord2D c1, Coord2D c2)
	{
		return c1.x == c2.x && c1.y == c2.y;
	}

	public static bool operator !=(Coord2D c1, Coord2D c2)
	{
		return !(c1 == c2);
	}

	public static Coord2D operator +(Coord2D c1, Coord2D c2)
	{
		return new Coord2D(c1.x + c2.x, c1.y + c2.y);
	}

	public static Coord2D operator -(Coord2D c1, Coord2D c2)
	{
		return new Coord2D(c1.x - c2.x, c1.y - c2.y);
	}
}