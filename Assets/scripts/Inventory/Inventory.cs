using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Image[] itemImages = new Image[num_item_slots];
    public Item[] items = new Item[num_item_slots];
    public const int num_item_slots = 5;

    public void AddItem(Item item_to_add) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                items[i] = item_to_add;
                itemImages[i].sprite = item_to_add.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(Item item_to_remove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item_to_remove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
}
