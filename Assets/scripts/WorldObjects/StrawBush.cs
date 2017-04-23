using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrawBush : MonoBehaviour {

    public GameObject rope_prefab;
    public float y_spawn_offset;

    private TextDisplay story_text_display;
    private StoryManager story_manager;

    public void Start() {
        story_text_display = FindObjectOfType<TextDisplay>();
        story_manager = FindObjectOfType<StoryManager>();
    }

    public void OnMouseDown() {

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        int event_time = story_manager.GetEventTime(StoryEvent.MakeRope);
        story_text_display.ShowText("Do you want to make a rope out of this bush?\n(" + event_time + " hours)", this.gameObject, button_prompt: true, yes_event: StoryEvent.MakeRope);
    }

    public void AddRopeToInventory() {
        GameObject reward_instance = Instantiate(this.rope_prefab);
        reward_instance.transform.position = new Vector3(transform.position.x, transform.position.y + y_spawn_offset, transform.position.z);
        Destroy(this.gameObject);
    }
}
