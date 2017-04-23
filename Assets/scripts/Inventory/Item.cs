using UnityEngine;

public class Item {

    private GameObject item_object;
    public Sprite sprite;
    public WorldObjectType object_type;

    public Item(GameObject item_object, Sprite custom_sprite=null) {
        this.item_object = item_object;

        object_type = GetObjectType(item_object);

        if (custom_sprite == null) {
            sprite = item_object.GetComponent<SpriteRenderer>().sprite;
        }
        else {
            sprite = custom_sprite;
        }
    }

    public WorldObjectType GetObjectType(GameObject item_object) {

        if (item_object != null) {
            return item_object.GetComponent<WorldObjectInformation>().world_object_type;
        }
        else {
            return WorldObjectType.empty;
        }
    }
}
