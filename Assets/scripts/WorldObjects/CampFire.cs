using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CampFire : MonoBehaviour {

    public Sprite[] frames;
    public float burn_frame_time = 2f;

    private float burn_time;
    private int current_burn_frame;

    private SpriteRenderer rend;
    private TextDisplay story_controller;

    void Start () {
        burn_time = 0;
        current_burn_frame = 0;
        rend = GetComponent<SpriteRenderer>();
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
	}
	
	void Update () {
        burn_time += Time.deltaTime;
        if (burn_time > burn_frame_time) {
            ShiftBurnFrame();
            burn_time -= burn_frame_time;
        }
	}

    private void ShiftBurnFrame() {
        current_burn_frame += 1;
        if (current_burn_frame >= frames.Length) {
            current_burn_frame = 0;
        }

        rend.sprite = frames[current_burn_frame];
    }

    void OnMouseDown() {

        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        story_controller.ShowText("Time to end day?", this.gameObject, button_prompt:true, yes_event:StoryEvent.EndDay);
    }
}
