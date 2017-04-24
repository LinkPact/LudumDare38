using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StoryEvent {
    None,
    PickBerry,
    Fish,
    FishWithFishingRod,
    MakeRope,
    DigSpot,
    DigSpotWithShovel,
    CutTree,
    CutTreeWithAxe,
    BuildBoat,
    EndDay,
    Restart,
    SailBoat
}

public class StoryManager : MonoBehaviour {

    private NeedsManager needs_manager;
    private Inventory inventory;
    private TextDisplay story_controller;
    private Player player;

    public Dictionary<StoryEvent, int> event_time_dict;
    public string no_time_message = "Not enough time left of this day. Get some sleep by the fire";

    void Start () {
        needs_manager = FindObjectOfType<NeedsManager>();
        inventory = FindObjectOfType<Inventory>();
        story_controller = FindObjectOfType<TextDisplay>();
        player = FindObjectOfType<Player>();

        event_time_dict = new Dictionary<StoryEvent, int>();
        event_time_dict.Add(StoryEvent.PickBerry, 1);
        event_time_dict.Add(StoryEvent.Fish, 7);
        event_time_dict.Add(StoryEvent.FishWithFishingRod, 2);
        event_time_dict.Add(StoryEvent.MakeRope, 3);
        event_time_dict.Add(StoryEvent.DigSpot, 4);
        event_time_dict.Add(StoryEvent.DigSpotWithShovel, 2);
        event_time_dict.Add(StoryEvent.CutTree, 7);
        event_time_dict.Add(StoryEvent.CutTreeWithAxe, 3);
        event_time_dict.Add(StoryEvent.BuildBoat, 8);
        event_time_dict.Add(StoryEvent.SailBoat, 0);
    }

    public int GetEventTime(StoryEvent target_event) {
        print(target_event);
        int event_time = event_time_dict[target_event];
        return event_time;
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
                Fishing(caller, StoryEvent.Fish);
                break;
            case StoryEvent.FishWithFishingRod:
                Fishing(caller, StoryEvent.FishWithFishingRod);
                break;
            case StoryEvent.MakeRope:
                MakeRope(caller);
                break;
            case StoryEvent.DigSpot:
                DigOnSpot(caller, StoryEvent.DigSpot);
                break;
            case StoryEvent.DigSpotWithShovel:
                DigOnSpot(caller, StoryEvent.DigSpotWithShovel);
                break;
            case StoryEvent.CutTree:
                CutDownTree(caller, StoryEvent.CutTree);
                break;
            case StoryEvent.CutTreeWithAxe:
                CutDownTree(caller, StoryEvent.CutTreeWithAxe);
                break;
            case StoryEvent.BuildBoat:
                BuildBoat(caller);
                break;
            case StoryEvent.SailBoat:
                SailBoat(caller);
                break;
            case StoryEvent.Restart:
                Restart();
                break;
            case StoryEvent.None:
                throw new System.Exception("None event triggered");
            default:
                throw new System.Exception("Unknown trigger event: " + story_event);
        }
    }

    private void PickBerryEvent(GameObject caller) {
        if (needs_manager.TimeRemaining >= event_time_dict[StoryEvent.PickBerry]) {
            needs_manager.SpendTime(event_time_dict[StoryEvent.PickBerry]);
            needs_manager.ReduceHunger(caller.GetComponent<BerryBush>().food_value);
            caller.GetComponent<BerryBush>().has_berries = false;
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void Fishing(GameObject caller, StoryEvent event_type) {
        if (needs_manager.TimeRemaining >= event_time_dict[event_type]) {
            needs_manager.SpendTime(event_time_dict[event_type]);
            needs_manager.ReduceHunger(caller.GetComponent<Fish>().food_value);
            caller.GetComponent<Fish>().OnFishEvent();
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void MakeRope(GameObject caller) {
        if(needs_manager.TimeRemaining >= event_time_dict[StoryEvent.MakeRope]) {
            caller.GetComponent<StrawBush>().AddRopeToInventory();
            needs_manager.SpendTime(event_time_dict[StoryEvent.MakeRope]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void DigOnSpot(GameObject caller, StoryEvent event_type) {
        if (needs_manager.TimeRemaining >= event_time_dict[event_type]) {
            caller.GetComponent<DiggingSpot>().AddRewardToInventory();
            needs_manager.SpendTime(event_time_dict[event_type]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void CutDownTree(GameObject caller, StoryEvent event_type) {
        if (needs_manager.TimeRemaining >= event_time_dict[event_type]) {
            caller.GetComponent<Tree>().AddWoodToInventory();
            needs_manager.SpendTime(event_time_dict[event_type]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void BuildBoat(GameObject caller) {
        if (needs_manager.TimeRemaining >= event_time_dict[StoryEvent.BuildBoat]) {
            ShipWreck ship = caller.GetComponent<ShipWreck>();
            ship.PerformRepairs();
            inventory.ConsumeItems(ship.GetRepairItems());
            needs_manager.SpendTime(event_time_dict[StoryEvent.BuildBoat]);
        }
        else {
            story_controller.ShowText(no_time_message, this.gameObject);
        }
    }

    private void SailBoat(GameObject caller) {
        ShipWreck ship = caller.GetComponent<ShipWreck>();
        FindObjectOfType<FadeIn>().StartFade();
        ship.SetSail();
    }

    private void StartNewDayEvent() {
        FindObjectOfType<FadeIn>().StartFade();
        needs_manager.StartNewDay();
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
