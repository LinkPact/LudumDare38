using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsManager : MonoBehaviour {

    public float hunger;
    public float hunger_max;
    public float hunger_degen_time;    

	void Start () {
		
	}
	
	void Update () {
        hunger -= hunger_degen_time * Time.deltaTime;
	}

    public void ReduceHunger(float value)
    {
        hunger += value;
        if (hunger > hunger_max) {
            hunger = hunger_max;
        }
    }
}
