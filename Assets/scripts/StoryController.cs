using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StoryEvent {
    None,
    EndDay
}

public class StoryController : MonoBehaviour {

    public void ToggleDisplay(bool display_text) {
        this.display_text = display_text;
        display_has_changed = true;
    }

    public bool display_text;
    public bool display_has_changed;
    private bool button_prompted;
    private StoryEvent yes_event;

    private Panel panel;
    private Text text;
    private YesButton yes_button;
    private NoButton no_button;

    private float display_time;
    public float min_display_time = 0.1f;

    private DisplayElements display_elements;
    private NeedsManager needs_manager;

    public void ShowText(string message, bool button_prompt=false, StoryEvent yes_event=StoryEvent.None) {

        text.text = message;
        ToggleDisplay(true);
        button_prompted = button_prompt;
        this.yes_event = yes_event;
    }

    public void TrigEvent() {
        switch (yes_event) {
            case StoryEvent.EndDay:
                print("End day triggered!");
                needs_manager.StartNewDay();
                break;
            case StoryEvent.None:
                print("None triggered!");
                break;
            default:
                throw new System.Exception("Unknown trigger event: " + yes_event);
        }
    }

	void Start () {

        display_text = false;
        display_elements = GetComponentInChildren<DisplayElements>();
        text = GetComponentInChildren<Text>();
        display_has_changed = true;
        display_time = 0;

        text.text = "text";
        yes_button = GetComponentInChildren<YesButton>();
        no_button = GetComponentInChildren<NoButton>();
        button_prompted = false;

        needs_manager = FindObjectOfType<NeedsManager>();
    }

    void Update () {

        if (button_prompted) {
            PerformButtonPrompt();
        }
        else if (display_text && display_time > min_display_time 
            && Input.GetMouseButtonDown(0)) {
            ToggleDisplay(false);
            display_time = 0;
        }

        UpdateTextDisplay();
    }

    private void PerformButtonPrompt() {

    }

    private void UpdateTextDisplay() {

        if (display_text) {
            display_time += Time.deltaTime;
        }

        if (display_has_changed) {
            display_has_changed = false;
            display_elements.gameObject.SetActive(display_text);

            yes_button.gameObject.SetActive(button_prompted);
            no_button.gameObject.SetActive(button_prompted);
        }
    }
}
