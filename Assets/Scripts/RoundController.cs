using UnityEngine;
using System.Collections.Generic;

public class RoundController : MonoBehaviour
{
	public Dictionary<RoboController, bool> RoboReadyDictionary;
	public event System.Action NewRound;
	public event System.Action AllReady;

	public int ReadyCount
	{
		get
		{
			int count = 0;
			foreach (bool ready in RoboReadyDictionary.Values)
			{
				if (ready)
					count++;
			}
			return count;
		}
	}

	public bool AllAreReady
	{
		get
		{
			return ReadyCount == RoboReadyDictionary.Count;
		}
	}

	public RoundController()
	{
		RoboReadyDictionary = new Dictionary<RoboController, bool>();
	}

	public void RegisterRobo(RoboController robo)
	{
		robo.RoboReady += RoboReady;
		AllReady += robo.NewRound;

		RoboReadyDictionary.Add(robo, false);
	}

	public void UnregisterRobo(RoboController robo)
	{
		robo.RoboReady -= RoboReady;
		AllReady -= robo.NewRound;
		
		RoboReadyDictionary.Remove(robo);
	}

	public void RoboReady(RoboController robo)
	{
		RoboReadyDictionary[robo] = true;

		if (AllAreReady)
		{
			AllReady();
		}
	}

	public void RoboUnready(RoboController robo)
	{
		RoboReadyDictionary[robo] = false;
	}
}
