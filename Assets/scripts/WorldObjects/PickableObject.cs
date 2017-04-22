using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour {

    private TextDisplay story_controller;
    public string message = "template message";
    private Inventory inventory;
    public Item item_to_spawn;

    void Start()
    {
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    void OnMouseDown()
    {
        story_controller.ShowText(message, this.gameObject);
        inventory.AddItem(Instantiate(item_to_spawn));
        Destroy(gameObject);
    }
}
