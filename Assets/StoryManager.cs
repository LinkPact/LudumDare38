using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryEvent {
    None,
    PickBerry,
    EatBerry,
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
            case StoryEvent.EatBerry:
                EatBerry(caller);
                break;
            case StoryEvent.None:
                throw new System.Exception("None event triggered");
            default:
                throw new System.Exception("Unknown trigger event: " + story_event);
        }
    }

    private void PickBerryEvent(GameObject caller) {
        needs_manager.SpendTime(1);
        // inventory.AddItem(new Item(this.gameObject, custom_sprite: berry_sprite));
        caller.GetComponent<BerryBush>().AddBerryToInventory();
        Debug.Log("PickBerry event" + needs_manager.Time_remaing);
    }

    private void EatBerry(GameObject caller) {
        //needs.ReduceHunger(food_value);
        //inventory.RemoveItem();
    }
    private void StartNewDayEvent() {
        print("End day triggered!!");
        needs_manager.StartNewDay();
    }
}
