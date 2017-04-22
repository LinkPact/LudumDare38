using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButton : MonoBehaviour {

    private StoryController story_controller;

    void Start () {
        story_controller = GetComponentInParent<StoryController>();
	}
	
    public void TestLog() {
        print("Yes Test!");
        story_controller.ToggleDisplay(false);
        story_controller.TrigEvent();
    }
}
