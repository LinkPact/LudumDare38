using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

    private StoryController story_controller;
    public string message = "template message";

    void Start () {
        story_controller = GameObject.FindObjectOfType<StoryController>();
    }

    void OnMouseDown() {
        story_controller.ShowText(message);
        Destroy(gameObject);
    }
}
