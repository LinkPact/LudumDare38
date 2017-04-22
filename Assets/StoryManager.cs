using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryEvent {
    None,
    EndDay
}

public class StoryManager : MonoBehaviour {

    private NeedsManager needs_manager;

	void Start () {
        needs_manager = FindObjectOfType<NeedsManager>();
	}
	
    public void TrigEvent(StoryEvent story_event, GameObject caller) {
        switch (story_event) {
            case StoryEvent.EndDay:
                StartNewDayEvent();
                break;
            case StoryEvent.None:
                throw new System.Exception("None event triggered");
            default:
                throw new System.Exception("Unknown trigger event: " + story_event);
        }
    }

    private void StartNewDayEvent() {
        print("End day triggered!!");
        needs_manager.StartNewDay();
    }
}
