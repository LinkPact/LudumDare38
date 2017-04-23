using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    public Item fish_item;
    public float food_value;

    private TextDisplay story_text_display;
    public string message = "template message";

    void Start () {
        story_text_display = FindObjectOfType<TextDisplay>();
    }

    void OnMouseDown() {
        story_text_display.ShowText(message, this.gameObject, button_prompt: true, yes_event: StoryEvent.Fish);
    }

    public void OnFishEvent() {
        Destroy(gameObject);
    } 
}
