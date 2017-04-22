using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour {

    private StoryController story_controller;

    public string message = "template message";

	void Start () {
        story_controller = GameObject.FindObjectOfType<StoryController>();
	}
	
    void OnMouseDown() {
        story_controller.ShowText(message);
    }
}
