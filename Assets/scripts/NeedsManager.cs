using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsManager : MonoBehaviour {

    public float hunger;
    public float hunger_max;
    public float hunger_degen_time;

    private DayEvents day_events;
    private Player player;
    private TextDisplay story_manager;

    private int day;
    public int Day {
        get {
            return day;
        }
    }

    public int time_in_a_day = 12;
    private int time_remaining;
    public int TimeRemaining {
        get {
            return time_remaining;
        }
    }

	void Start () {
        day = 1;
        time_remaining = time_in_a_day;
        day_events = FindObjectOfType<DayEvents>();
        player = FindObjectOfType<Player>();
        story_manager = GameObject.FindObjectOfType<TextDisplay>();
    }

    private void Update() {
        if (hunger < 0) {
            Debug.Log("You died");
            player.Died();
            story_manager.ShowText("You died! Play again?", this.gameObject, button_prompt: true, yes_event: StoryEvent.Restart);
        }

    }

    public void ReduceHunger(float value) {
        hunger += value;
        if (hunger > hunger_max) {
            hunger = hunger_max;
        }
    }

    public float GetHungerFraction() {
        return hunger / hunger_max;
    }

    public bool SpendTime(int time) {
        if (time <= time_remaining) {
            hunger -= hunger_degen_time * time;
            time_remaining -= time;
            return true;
        }
        return false;
    }

    public void StartNewDay() {
        day += 1;
        time_remaining = time_in_a_day;
        day_events.ActivateDay(day);
    }

}
