using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    private Inventory inventory;
    public Item fish_item;

    void Start () {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }
	
	void Update () {
		
	}

    void OnMouseDown() {
        // inventory.AddItem(Instantiate(fish_item));
        inventory.AddItem(new Item(this.gameObject));
        Destroy(gameObject);
    }
}
