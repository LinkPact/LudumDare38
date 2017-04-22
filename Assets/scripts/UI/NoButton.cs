using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour {

    private StoryController story_controller;

    void Start () {
        story_controller = GetComponentInParent<StoryController>();
    }

    void Update () {
		
	}

    public void TestLog() {
        print("No Test!");
        story_controller.ToggleDisplay(false);
    }
}
