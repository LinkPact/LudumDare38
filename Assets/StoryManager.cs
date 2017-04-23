﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoryEvent {
    None,
    PickBerry,
    EatBerry,
    MakeRope,
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
            case StoryEvent.MakeRope:
                MakeRope(caller);
                break;
            case StoryEvent.None:
                throw new System.Exception("None event triggered");
            default:
                throw new System.Exception("Unknown trigger event: " + story_event);
        }
    }

    private void PickBerryEvent(GameObject caller) {
        needs_manager.SpendTime(1);
        caller.GetComponent<BerryBush>().AddBerryToInventory();
    }

    private void EatBerry(GameObject caller) {
        //needs.ReduceHunger(food_value);
        //inventory.RemoveItem();
    }

    private void MakeRope(GameObject caller) {
        caller.GetComponent<StrawBush>().AddRopeToInventory();
        needs_manager.SpendTime(3);

    }

    private void StartNewDayEvent() {
        print("End day triggered!!");
        needs_manager.StartNewDay();
    }
}
