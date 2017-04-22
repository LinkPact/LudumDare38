using UnityEngine;

public class Item {

    private GameObject item_object;
    public Sprite sprite;

    public Item(GameObject item_object, Sprite custom_sprite=null) {
        this.item_object = item_object;

        if (custom_sprite == null) {
            sprite = this.item_object.GetComponent<SpriteRenderer>().sprite;
        }
        else {
            sprite = custom_sprite;
        }
    }
}
