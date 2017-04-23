using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingSpot : MonoBehaviour {

    public Sprite[] frames;
    private bool is_digged;
    public GameObject reward_prefab;
    public float y_spawn_offset;

    private TextDisplay story_text_display;
    private SpriteRenderer rend;

    void Start () {
        is_digged = false;
        story_text_display = FindObjectOfType<TextDisplay>();
        rend = GetComponent<SpriteRenderer>();
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

        if (!is_digged) {
            story_text_display.ShowText("Let's dig!", this.gameObject, button_prompt: true, yes_event: StoryEvent.DigSpot);
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
