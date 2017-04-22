using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWreck : MonoBehaviour {

    private TextDisplay story_display;

    void Start () {
        story_display = FindObjectOfType<TextDisplay>();
	}
	
    void OnMouseDown() {
        story_display.ShowText("Maybe we can use this to get away from here...", this.gameObject);
    }
}
