using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEvents : MonoBehaviour {

    public GameObject[] day_objects;

    public void ActivateDay(int day) {
        if (day <= day_objects.Length) {
            day_objects[day - 1].SetActive(true);
        }
    }

    void Start() {
        InactivateAll();
        day_objects[0].SetActive(true);
    }

    private void InactivateAll() {
        foreach (GameObject day_object in day_objects) {
            day_object.SetActive(false);
        }
    }
}
