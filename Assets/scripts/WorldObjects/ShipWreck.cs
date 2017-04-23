using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWreck : MonoBehaviour {

    private TextDisplay story_display;
    private Inventory inventory;
    private NeedsManager needs_manager;
    private StoryManager story_manager;
    private SailingShip sailing_ship;

    public Sprite[] repair_stages;
    private SpriteRenderer sprite_renderer;
    public WorldObjectType[] repair_items;

    private int current_repair_levels;
    public int total_repair_levels;

    public WorldObjectType[] GetRepairItems() {
        return repair_items;
    }

    public void PerformRepairs() {
        current_repair_levels += 1;
    }

    public bool RepairsDone() {
        return current_repair_levels >= total_repair_levels;
    }

    public void SetSail() {
        sailing_ship.has_sailed = true;
    }

    void Start() {
        story_display = FindObjectOfType<TextDisplay>();
        inventory = FindObjectOfType<Inventory>();
        needs_manager = FindObjectOfType<NeedsManager>();
        story_manager = FindObjectOfType<StoryManager>();
        sailing_ship = FindObjectOfType<SailingShip>();
        sprite_renderer = GetComponent<SpriteRenderer>();

        current_repair_levels = 0;
    }

    void Update() {
        sprite_renderer.sprite = repair_stages[current_repair_levels];
    }

    void OnMouseDown() {

        int repair_time = story_manager.GetEventTime(StoryEvent.BuildBoat);

        print(repair_items);

        bool has_items = inventory.ItemsInInventory(repair_items);
        bool has_time = needs_manager.TimeRemaining >= repair_time;

        print(has_items);

        if (!RepairsDone()) {
            if (has_items && has_time) {
                story_display.ShowText("Spend day repairing boat. Consumes wood and rope.\n(" + repair_time + " hours)", this.gameObject, button_prompt: true, yes_event: StoryEvent.BuildBoat);
            }
            else {
                story_display.ShowText("A boat! I need wood, rope and " + repair_time + " hours to try repairing it.", this.gameObject);
            }
        }
        else {
            story_display.ShowText("The boat is done! Set sail?", this.gameObject, button_prompt: true, yes_event: StoryEvent.SailBoat);
        }
    }
}
