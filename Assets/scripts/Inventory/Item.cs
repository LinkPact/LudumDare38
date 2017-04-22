using UnityEngine;

public class Item {

    private GameObject item_object;
    public Sprite sprite;

    public Item(GameObject item_object) {
        this.item_object = item_object;
        sprite = this.item_object.GetComponent<SpriteRenderer>().sprite;
    }
}
