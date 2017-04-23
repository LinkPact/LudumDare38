using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    public GameObject wood_prefab;
    public float y_spawn_offset;

    private TextDisplay story_text_display;
    public string message = "template message";

    void Start () {
        story_text_display = FindObjectOfType<TextDisplay>();
    }

    public void OnMouseDown() {
        story_text_display.ShowText("Cut down tree?", this.gameObject, button_prompt: true, yes_event: StoryEvent.CutTree);
    }

    public void AddWoodToInventory() {
        GameObject reward_instance = Instantiate(this.wood_prefab);
        reward_instance.transform.position = new Vector3(transform.position.x, transform.position.y + y_spawn_offset, transform.position.z);
        Destroy(this.gameObject);
    }
}
