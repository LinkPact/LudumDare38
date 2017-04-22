using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButton : MonoBehaviour {

    private TextDisplay story_controller;

    void Start () {
        story_controller = GetComponentInParent<TextDisplay>();
	}
	
    public void TestLog() {
        print("Yes Test!");
        story_controller.ToggleDisplay(false);
        story_controller.TrigEvent();
    }
}
