using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryEvent {
    None,
    PickBerry,
    Fish,
    MakeRope,
    DigSpot,
    CutTree,
    BuildBoat,
    EndDay
}

public class StoryManager : MonoBehaviour {

    private NeedsManager needs_manager;
    private Inventory inventory;
    private TextDisplay story_controller;

    public Dictionary<StoryEvent, int> event_time_dict;
    public string no_time_message = "Not enough time left of this day. Get some sleep by the fire";

    void Start () {
        needs_manager = FindObjectOfType<NeedsManager>();
        inventory = FindObjectOfType<Inventory>();
        story_controller = GameObject.FindObjectOfType<TextDisplay>();

        event_time_dict = new Dictionary<StoryEvent, int>();
        event_time_dict.Add(StoryEvent.PickBerry, 1);
        event_time_dict.Add(StoryEvent.Fish, 4);
        event_time_dict.Add(StoryEvent.MakeRope, 4);
        event_time_dict.Add(StoryEvent.DigSpot, 3);
        event_time_dict.Add(StoryEvent.CutTree, 6);
        event_time_dict.Add(StoryEvent.BuildBoat, 12);
    }
	
    public void TrigEvent(StoryEvent story_event, GameObject caller) {
        switch (story_event) {
            case StoryEvent.EndDay:
                StartNewDayEvent();
                break;
            case StoryEvent.PickBerry:
                PickBerryEvent(caller);
                break;
            case StoryEvent.Fish:
                Fishing(caller);
                break;
            case StoryEvent.MakeRope:
                MakeRope(caller);
                break;
            case StoryEvent.DigSpot:
                DigOnSpot(caller);
                break;
            case StoryEvent.CutTree:
                CutDownTree(caller);
                break;
            case StoryEvent.BuildBoat:
                BuildBoat(caller);
                break;
            case StoryEvent.None:
                throw new System.Exception("None event triggered");
            default:
                throw new System.Exception("Unknown trigger event: " + story_event);
        }
    }

    private void PickBerryEvent(GameObject caller) {
        if (needs_manager.Time_remaing >= event_time_dict[StoryEvent.PickBerry]) {
            needs_manager.SpendTime(event_time_dict[StoryEvent.PickBerry]);
            needs_manager.ReduceHunger(caller.GetComponent<BerryBush>().food_value);
            caller.GetComponent<BerryBush>().has_berries = false;
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void Fishing(GameObject caller) {
        if (needs_manager.Time_remaing >= event_time_dict[StoryEvent.Fish]) {
            needs_manager.SpendTime(event_time_dict[StoryEvent.Fish]);
            needs_manager.ReduceHunger(caller.GetComponent<Fish>().food_value);
            caller.GetComponent<Fish>().OnFishEvent();
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void MakeRope(GameObject caller) {
        if(needs_manager.Time_remaing >= event_time_dict[StoryEvent.MakeRope]) {
            caller.GetComponent<StrawBush>().AddRopeToInventory();
            needs_manager.SpendTime(event_time_dict[StoryEvent.MakeRope]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void DigOnSpot(GameObject caller) {
        if (needs_manager.Time_remaing >= event_time_dict[StoryEvent.DigSpot]) {
            caller.GetComponent<DiggingSpot>().AddRewardToInventory();
            needs_manager.SpendTime(event_time_dict[StoryEvent.DigSpot]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void CutDownTree(GameObject caller) {
        if (needs_manager.Time_remaing >= event_time_dict[StoryEvent.CutTree]) {
            caller.GetComponent<Tree>().AddWoodToInventory();
            needs_manager.SpendTime(event_time_dict[StoryEvent.CutTree]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void BuildBoat(GameObject caller) {
        if (needs_manager.Time_remaing >= event_time_dict[StoryEvent.BuildBoat]) {
            story_controller.ShowText("You survived the island!", this.gameObject);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void StartNewDayEvent() {
        print("End day triggered!!");
        needs_manager.StartNewDay();
    }
}
