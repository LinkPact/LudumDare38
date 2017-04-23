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
    public Sprite berry_sprite;
    private TextDisplay story_controller;
    public string message = "template message";
    public string no_berries_message = "No berries for you!";

	void Start () {
        sprite_renderer = GetComponent<SpriteRenderer>();
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
        has_berries = true;
	}
	
	void Update () {
        AssignSprite();
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
            story_controller.ShowText(message, this.gameObject, button_prompt: true, yes_event: StoryEvent.PickBerry);
        }
        else {
            story_controller.ShowText(no_berries_message, this.gameObject);
        }
    }
}
