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
    EndDay
}

public class StoryManager : MonoBehaviour {

    private NeedsManager needs_manager;
    private Inventory inventory;

    void Start () {
        needs_manager = FindObjectOfType<NeedsManager>();
        inventory = FindObjectOfType<Inventory>();
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
            case StoryEvent.None:
                throw new System.Exception("None event triggered");
            default:
                throw new System.Exception("Unknown trigger event: " + story_event);
        }
    }

    private void PickBerryEvent(GameObject caller) {
        needs_manager.SpendTime(1);
        needs_manager.ReduceHunger(caller.GetComponent<BerryBush>().food_value);
        caller.GetComponent<BerryBush>().has_berries = false;
    }

    private void Fishing(GameObject caller) {
        needs_manager.SpendTime(4);
        needs_manager.ReduceHunger(caller.GetComponent<Fish>().food_value);
        caller.GetComponent<Fish>().OnFishEvent();
    }

    private void MakeRope(GameObject caller) {
        caller.GetComponent<StrawBush>().AddRopeToInventory();
        needs_manager.SpendTime(3);

    }

    private void DigOnSpot(GameObject caller) {
        caller.GetComponent<DiggingSpot>().AddRewardToInventory();
        needs_manager.SpendTime(4);
    }

    private void CutDownTree(GameObject caller) {
        caller.GetComponent<Tree>().AddWoodToInventory();
        needs_manager.SpendTime(6);
    }

    private void StartNewDayEvent() {
        print("End day triggered!!");
        needs_manager.StartNewDay();
    }
}
