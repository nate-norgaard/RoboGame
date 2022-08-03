using UnityEngine;
using System.Collections;

public class PlayerRoboController : RoboController
{
	void Update ()
	{
		if (!ready)
		{
			if (Input.GetKeyDown(KeyCode.D))
			{
				//robo.Turn(LeftRight.Right);
				AddAction(new TurnAction(LeftRight.Right));
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				//robo.Turn(LeftRight.Left);
				AddAction(new TurnAction(LeftRight.Left));
			}
			if (Input.GetKeyDown(KeyCode.W))
			{
				//robo.Move(1);
				AddAction(new MoveAction(1));
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				//robo.Move(-1);
				AddAction(new MoveAction(-1));
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				//robo.Move(3);
				AddAction(new MoveAction(3));
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				RoboIsReady();
			}
		}
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			RemoveAction();
		}
	}
}
