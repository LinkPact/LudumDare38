using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageInABottle : MonoBehaviour {

    private TextDisplay story_controller;

    public string message = "template message";

	void Start () {
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
	}
	
    void OnMouseDown() {
        story_controller.ShowText(message, this.gameObject);
        Destroy(gameObject);
    }
}
