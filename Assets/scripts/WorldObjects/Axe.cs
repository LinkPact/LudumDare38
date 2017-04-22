using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

    private TextDisplay story_controller;
    public string message = "template message";
    private Inventory inventory;
    public Item axe_item;

    void Start () {
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    void OnMouseDown() {
        story_controller.ShowText(message);
        inventory.AddItem(Instantiate(axe_item));
        Destroy(gameObject);
    }
}
