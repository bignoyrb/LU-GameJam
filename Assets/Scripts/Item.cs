using UnityEngine;
using System.Collections;

public class Item {

	public string itemName;
	public int itemID;
	public string itemDescription;
	public Sprite itemIcon;
	public GameObject itemModel;
	public int itemPower;
	public int itemSpeed;
	public int itemValue;
	public ItemType itemType;

	public enum ItemType
	{
		Weapon,
		Consumable,
		Quest,
		Head,
		Shoe,
		Chest,
		Pants,
		Neck,
		Ring,
		Hand
	}

	public Item(string name, int id, string desc, int power, int speed, int value, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDescription = desc;
		itemPower = power;
		itemSpeed = speed;
		itemValue = value;
		itemType = type;
		//itemIcon = Sprites.Load<Sprite>("" + name);
	}

	public Item()
	{
		
	}
}
