using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour
{
	public RoboController RoboController;
	public ActionUI[] ActionUis;
	public Action[] Actions;

	public void Start()
	{
		Actions = RoboController.actions;
		RoboController.UpdateRoboController += UpdateActionUi;
	}

	public void UpdateActionUi()
	{
		for (int i = 0; i < Actions.Length && i < ActionUis.Length; i++)
		{
			ActionUis[i].SetAction(Actions[i]);
		}
	}
}
