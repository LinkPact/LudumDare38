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

    private float display_time;
    public float min_display_time = 0.1f;

    private DisplayElements display_elements;

    public void ShowText(string message) {

        text.text = message;
        ToggleDisplay(true);
    }

	void Start () {

        display_text = false;
        display_elements = GetComponentInChildren<DisplayElements>();
        text = GetComponentInChildren<Text>();
        display_has_changed = true;
        display_time = 0;

        text.text = "text";
	}
	
	void Update () {

        if (display_text && display_time > min_display_time && Input.GetMouseButtonDown(0)) {
            ToggleDisplay(false);
            display_time = 0;
        }

        UpdateTextDisplay();
    }

    private void UpdateTextDisplay() {

        if (display_text) {
            display_time += Time.deltaTime;
        }

        if (display_has_changed) {
            display_has_changed = false;
            display_elements.gameObject.SetActive(display_text);
        }
    }
}
