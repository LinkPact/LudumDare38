using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Image[] itemImages = new Image[num_item_slots];
    public Item[] items = new Item[num_item_slots];
    public const int num_item_slots = 5;

    public GameObject rope_prefab;
    public GameObject sharp_stone_prefab;
    public GameObject flat_stone_prefab;
    public GameObject fishing_rod_prefab;
    public GameObject axe_prefab;
    public GameObject wood_prefab;
    public GameObject shovel_prefab;

    private Player player;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    public bool IsInventoryFull() {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                return false;
            }
        }
        return true;
    }

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

    public void RemoveItem(Item item_to_remove) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == item_to_remove) {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void DropItemAtIndex(int index) {

        Item target_item = items[index];
        WorldObjectType object_type = target_item.object_type;

        GameObject drop_instance;

        switch (object_type) {
            case WorldObjectType.axe:
                drop_instance = Instantiate(axe_prefab);
                break;
            case WorldObjectType.sharp_stone:
                drop_instance = Instantiate(sharp_stone_prefab);
                break;
            case WorldObjectType.flat_stone:
                drop_instance = Instantiate(flat_stone_prefab);
                break;
            case WorldObjectType.rope:
                drop_instance = Instantiate(rope_prefab);
                break;
            case WorldObjectType.fishing_rod:
                drop_instance = Instantiate(fishing_rod_prefab);
                break;
            case WorldObjectType.shovel:
                drop_instance = Instantiate(shovel_prefab);
                break;
            case WorldObjectType.wood:
                drop_instance = Instantiate(wood_prefab);
                break;
            default:
                throw new Exception("Currently unsupported object type: " + object_type);
        }

        drop_instance.transform.position = player.transform.position;

        if (target_item != null) {
            RemoveItem(target_item);
        }
    }

    public bool ItemsInInventory(WorldObjectType[] target_items) {
        foreach (WorldObjectType obj_type in target_items) {
            if (!ItemInInventory(obj_type)) {
                return false;
            }
        }
        return true;
    }

    public bool ItemInInventory(WorldObjectType object_type) {

        foreach (Item item in items) {

            if (item == null) {
                continue;
            }

            if (item.object_type == object_type) {
                return true;
            }
        }
        return false;
    }

    public void ConsumeItems(WorldObjectType[] target_items) {
        foreach (WorldObjectType obj_type in target_items) {
            foreach (Item item in items) {
                if (item == null) {
                    continue;
                }

                if (item.object_type == obj_type) {
                    RemoveItem(item);
                    break;
                }
            }
        }
    }
}
