using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    public Item fish_item;
    public float food_value;

    private TextDisplay story_text_display;
    public string message = "template message";

    private Inventory inventory;
    private StoryManager story_manager;

    void Start () {
        story_text_display = FindObjectOfType<TextDisplay>();
        inventory = FindObjectOfType<Inventory>();
        story_manager = FindObjectOfType<StoryManager>();
    }

    void OnMouseDown() {

        int event_time;
        StoryEvent story_event;
        string message;

        if (inventory.ItemInInventory(WorldObjectType.fishing_rod)) {
            story_event = StoryEvent.FishWithFishingRod;
            message = "Fish with fishing rod?";
        }
        else {
            story_event = StoryEvent.Fish;
            message = "Hunt for fish? It would be much easier with a fishing rod.";
        }

        event_time = story_manager.GetEventTime(story_event);
        story_text_display.ShowText(message + " (" + event_time + " hours)", this.gameObject, button_prompt: true, yes_event: story_event);
    }

    public void OnFishEvent() {
        Destroy(gameObject);
    } 
}
