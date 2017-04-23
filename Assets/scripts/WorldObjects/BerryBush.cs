using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public string no_berries_message = "No more berries for you!";
    private StoryManager story_manager;

    void Start () {
        sprite_renderer = GetComponent<SpriteRenderer>();
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
        has_berries = true;
        story_manager = FindObjectOfType<StoryManager>();
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

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (has_berries) {
            int event_time = story_manager.GetEventTime(StoryEvent.PickBerry);
            story_controller.ShowText("Pick and eat berries? (" + event_time + " hour)", this.gameObject, button_prompt: true, yes_event: StoryEvent.PickBerry);
        }
        else {
            story_controller.ShowText(no_berries_message, this.gameObject);
        }
    }
}
