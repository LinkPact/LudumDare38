using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour {

    public void ToggleDisplay(bool display_text) {
        this.display_text = display_text;
        display_has_changed = true;
    }

    public bool display_text;
    public bool display_has_changed;

    private Panel panel;
    private Text text;

    private DisplayElements display_elements;

	void Start () {
        display_text = false;
        display_elements = GetComponentInChildren<DisplayElements>();
        display_has_changed = true;
	}
	
	void Update () {
        UpdateTextDisplay();

	}

    private void UpdateTextDisplay() {

        if (display_has_changed) {
            display_has_changed = false;
            display_elements.gameObject.SetActive(display_text);
        }
    }
}
