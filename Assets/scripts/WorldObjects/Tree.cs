using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tree : MonoBehaviour {

    public GameObject wood_prefab;
    public float y_spawn_offset;

    private TextDisplay story_text_display;
    public string message = "template message";

    private Inventory inventory;
    private StoryManager story_manager;

    void Start () {
        story_text_display = FindObjectOfType<TextDisplay>();
        inventory = FindObjectOfType<Inventory>();
        story_manager = FindObjectOfType<StoryManager>();
    }

    public void OnMouseDown() {

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        int event_time;
        StoryEvent story_event;
        string message;

        if (inventory.ItemInInventory(WorldObjectType.axe)) {
            story_event = StoryEvent.CutTreeWithAxe;
            message = "Cut down tree with axe?";
        }
        else {
            story_event = StoryEvent.CutTree;
            message = "Cut down tree? It would be much easier with an axe";
        }

        event_time = story_manager.GetEventTime(story_event);
        story_text_display.ShowText(message + "\n(" + event_time + " hours)", this.gameObject, button_prompt: true, yes_event: story_event);
    }

    public void AddWoodToInventory() {
        GameObject reward_instance = Instantiate(this.wood_prefab);
        reward_instance.transform.position = new Vector3(transform.position.x, transform.position.y + y_spawn_offset, transform.position.z);
        Destroy(this.gameObject);
    }
}
