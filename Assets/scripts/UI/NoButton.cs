using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour {

    private TextDisplay story_controller;

    void Start () {
        story_controller = GetComponentInParent<TextDisplay>();
    }

    void Update () {
		
	}

    public void TestLog() {
        print("No Test!");
        story_controller.ToggleDisplay(false);
    }
}
