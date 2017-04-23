using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWreck : MonoBehaviour {

    private TextDisplay story_display;

    void Start () {
        story_display = FindObjectOfType<TextDisplay>();
	}
	
    void OnMouseDown() {
        story_display.ShowText("Try to repair the boat to leave this cursed island, takes all day", this.gameObject, button_prompt: true, yes_event: StoryEvent.BuildBoat);
    }
}
