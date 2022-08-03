using UnityEngine;
using System.Collections;

public class RoboController : MonoBehaviour
{
	public GridAgent robo;
	public Action[] actions;
	public event System.Action UpdateRoboController;
	public event System.Action<RoboController> RoboReady;
	public event System.Action<RoboController> RoboUnready;
	public bool ready;

	public RoboController()
	{
		actions = new Action[5];
		ready = false;
	}

	public void AddAction(Action action)
	{
		for (int i = 0; i < actions.Length; i++)
		{
			if (actions[i] == null)
			{
				actions[i] = action;
				break;
			}
		}

		UpdateRoboController();
	}

	public void RemoveAction()
	{
		for (int i = actions.Length - 1; i >=0; i--)
		{
			if (actions[i] != null)
			{
				actions[i] = null;
				break;
			}
		}

		UpdateRoboController();
	}

	public void ClearActions()
	{
		for (int i = 0; i < actions.Length; i++)
		{
			actions[i] = null;
		}

		UpdateRoboController();
	}

	public void RoboIsReady()
	{
		ready = true;
		RoboReady(this);
	}

	public void RoboIsUnready()
	{
		ready = false;
		RoboUnready(this);
	}

	public void NewRound()
	{
		ClearActions();
		RoboIsUnready();
	}
}
