using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiggingSpot : MonoBehaviour {

    public Sprite[] frames;
    private bool is_digged;
    public GameObject reward_prefab;
    public float y_spawn_offset;

    private TextDisplay story_text_display;
    private SpriteRenderer rend;
    private Inventory inventory;
    private StoryManager story_manager;

    void Start () {
        is_digged = false;
        story_text_display = FindObjectOfType<TextDisplay>();
        rend = GetComponent<SpriteRenderer>();
        inventory = FindObjectOfType<Inventory>();
        story_manager = FindObjectOfType<StoryManager>();
    }

    void Update() {
        if (!is_digged) {
            rend.sprite = frames[0];
        }
        else {
            rend.sprite = frames[1];
        }
    }

    void OnMouseDown() {

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!is_digged) {
            int event_time;
            StoryEvent story_event;
            string message;

            if (inventory.ItemInInventory(WorldObjectType.shovel)) {
                story_event = StoryEvent.DigSpotWithShovel;
                message = "Dig up this spot with your shovel?";
            }
            else {
                story_event = StoryEvent.DigSpot;
                message = "Dig up this spot with your bare hands? Easier with a shovel.";
            }

            event_time = story_manager.GetEventTime(story_event);
            story_text_display.ShowText(message + "\n(" + event_time + " hours)", this.gameObject, button_prompt: true, yes_event: story_event);

        }
        else {
            story_text_display.ShowText("No more digging here, find another spot!", this.gameObject);
        }

    }

    public void AddRewardToInventory() {
        GameObject reward_instance = Instantiate(this.reward_prefab);
        reward_instance.transform.position = new Vector3(transform.position.x, transform.position.y + y_spawn_offset, transform.position.z);
        is_digged = true;
    }
}
