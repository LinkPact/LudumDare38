using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsManager : MonoBehaviour {

    public float hunger;
    public float hunger_max;
    public float hunger_degen_time;

    private int day;
    public int Day {
        get {
            return day;
        }
    }

	void Start () {
        day = 1;
	}
	
	void Update () {
        hunger -= hunger_degen_time * Time.deltaTime;
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

    public void StartNewDay() {
        day += 1;
    }

}
