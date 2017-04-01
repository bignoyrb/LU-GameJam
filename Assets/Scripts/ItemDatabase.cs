using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	// List of items.
	public List<Item> items = new List<Item>();

	// Use this for initialization
	void Start () {
		// Add items to the list.
		items.Add (new Item ("itemicons_0",0,"Sissy armor",10,10,1,Item.ItemType.Chest));
		items.Add (new Item ("itemicons_1",1,"Antidote",10,10,1,Item.ItemType.Consumable));
	}

}
