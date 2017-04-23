using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour {

    public int slot_number;

    private Inventory inventory;

    void Start() {
        inventory = FindObjectOfType<Inventory>();
    }

    public void DropItem() {
        inventory.DropItemAtIndex(slot_number);
    }
}
