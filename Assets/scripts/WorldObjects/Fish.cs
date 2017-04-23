using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        int event_time;
        StoryEvent story_event;
        string message;

        if (inventory.ItemInInventory(WorldObjectType.fishing_rod)) {
            story_event = StoryEvent.FishWithFishingRod;
            message = "Fish with fishing rod and eat fish?";
            event_time = story_manager.GetEventTime(story_event);
            story_text_display.ShowText(message + "\n(" + event_time + " hours)", this.gameObject, button_prompt: true, yes_event: story_event);
        }
        else {
            message = "You can't fish without a fishing rod. Craft one in the 'Crafting' menu.";
            story_text_display.ShowText(message, this.gameObject);
        }

    }

    public void OnFishEvent() {
        Destroy(gameObject);
    } 
}
