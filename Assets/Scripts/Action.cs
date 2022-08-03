
public interface Action
{
	string SpriteName { get; set; }

	void Do(GridAgent gridAgent);
}

public class MoveAction : Action
{
	public int NumSpaces;
	public string SpriteName { get; set; }

	public MoveAction(int numSpaces)
	{
		NumSpaces = numSpaces;

		// ugly while I work things out
		switch (numSpaces)
		{
			case 1:
				SpriteName = "forward1";
				break;
			case 2:
				SpriteName = "forward2";
				break;
			case 3:
				SpriteName = "forward3";
				break;
			case -1:
				SpriteName = "reverse1";
				break;
			default:
				SpriteName = "move";
				break;
		}
	}

	public void Do(GridAgent gridAgent)
	{
		gridAgent.Move(NumSpaces);
	}
}

public class TurnAction : Action
{
	public LeftRight Lr;
	public string SpriteName { get; set; }

	public TurnAction(LeftRight lr)
	{
		Lr = lr;

		// ugly while I work things out
		switch (lr)
		{
			case LeftRight.Left:
				SpriteName = "turnleft";
				break;
			case LeftRight.Right:
				SpriteName = "turnright";
				break;
			default:
				SpriteName = "turn";
				break;
		}
	}

	public void Do(GridAgent gridAgent)
	{
		gridAgent.Turn(Lr);
	}
}

