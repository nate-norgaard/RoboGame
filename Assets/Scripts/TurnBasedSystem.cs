using UnityEngine;
using System.Collections;

public class TurnBasedSystem : MonoBehaviour
{
	public TurnController turnController;
	public RoundController roundController;

	void Awake ()
	{
		turnController = GetComponent<TurnController>();
		roundController = GetComponent<RoundController>();
	}
	
	void Update ()
	{
	
	}
}
