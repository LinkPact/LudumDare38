using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftOption : MonoBehaviour {

    public WorldObjectType[] required_items;
    public GameObject craft_result;

    private Inventory inventory;
    private Button my_button;

    void Start () {
        inventory = FindObjectOfType<Inventory>();
        my_button = GetComponentInChildren<Button>();
	}
	
	void Update () {

		if (inventory.ItemsInInventory(required_items)) {
            my_button.interactable = true;
        }
        else {
            my_button.interactable = false;
        }
	}

    public void CraftItem() {
        inventory.ConsumeItems(required_items);
        GameObject new_object = Instantiate(craft_result);
        Item new_item = new Item(new_object);
        inventory.AddItem(new_item);
    }
}
