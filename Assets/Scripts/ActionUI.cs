using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ActionUI : MonoBehaviour
{
	public Sprite[] Sprites;
	public Action Action;
	public Dictionary<string, int> SpriteIndexDictionary;

	void Start ()
	{
		if (Sprites.Length == 0)
			throw new System.Exception("ActionUI does not have sprites!");

		SpriteIndexDictionary = new Dictionary<string, int>();
		SpriteIndexDictionary.Add("none", 0);
		SpriteIndexDictionary.Add("forward1", 1);
		SpriteIndexDictionary.Add("forward2", 2);
		SpriteIndexDictionary.Add("forward3", 3);
		SpriteIndexDictionary.Add("reverse1", 4);
		SpriteIndexDictionary.Add("turnleft", 5);
		SpriteIndexDictionary.Add("turnright", 6);

		SetAction(null);
	}
	
	public void SetAction(Action action)
	{
		Action = action;
		string spriteName = (action != null)? action.SpriteName : "none";
		GetComponent<Image>().sprite = Sprites[SpriteIndexDictionary[spriteName]];
	}
}
