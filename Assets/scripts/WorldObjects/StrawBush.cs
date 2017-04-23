using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawBush : MonoBehaviour {

    public GameObject rope_prefab;
    public float y_spawn_offset;

    private TextDisplay story_text_display;
    private SpriteRenderer rend;

    public void Start() {
        story_text_display = FindObjectOfType<TextDisplay>();
        rend = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown() {
        story_text_display.ShowText("Making a rope!", this.gameObject, button_prompt: true, yes_event: StoryEvent.MakeRope);
    }

    public void AddRopeToInventory() {
        GameObject reward_instance = Instantiate(this.rope_prefab);
        reward_instance.transform.position = new Vector3(transform.position.x, transform.position.y + y_spawn_offset, transform.position.z);
        Destroy(this.gameObject);
    }
}
