using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButton : MonoBehaviour {

    private TextDisplay story_text_displayer;

    void Start () {
        story_text_displayer = GetComponentInParent<TextDisplay>();
	}
	
    public void TestLog() {
        story_text_displayer.ToggleDisplay(false);
        story_text_displayer.TrigEvent();
    }
}
