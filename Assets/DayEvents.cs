using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEvents : MonoBehaviour {

    public GameObject[] day_objects;

    public void ActivateDay(int day) {
        day_objects[day - 1].SetActive(true);
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
