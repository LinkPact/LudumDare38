using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : MonoBehaviour {

    public Sprite[] sprites;

    public bool has_berries;
    public float food_value;

    public float berry_spawn_time;
    private float current_spawn_time;

    private SpriteRenderer sprite_renderer;
    private NeedsManager needs;
    private Inventory inventory;
    public Sprite berry_sprite;

	void Start () {
        sprite_renderer = GetComponent<SpriteRenderer>();
        needs = GameObject.FindObjectOfType<NeedsManager>();
        inventory = GameObject.FindObjectOfType<Inventory>();
        has_berries = true;
	}
	
	void Update () {

        UpdateSpawn();
        AssignSprite();
	}

    private void UpdateSpawn() {
        current_spawn_time += Time.deltaTime;
        if (current_spawn_time > berry_spawn_time) {
            has_berries = true;
            current_spawn_time = 0;
        }
    }

    private void AssignSprite() {
        if (has_berries) {
            sprite_renderer.sprite = sprites[0];
        }
        else {
            sprite_renderer.sprite = sprites[1];
        }
    }

    void OnMouseDown() {

        if (has_berries) {
            has_berries = false;
            needs.ReduceHunger(food_value);
            inventory.AddItem(new Item(this.gameObject, custom_sprite:berry_sprite));
            // inventory.AddItem(Instantiate(berry));
        }
    }
}
