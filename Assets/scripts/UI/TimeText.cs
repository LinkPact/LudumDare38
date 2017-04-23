using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    private NeedsManager needs_manager;
    private Text display_text;

    void Start() {
        needs_manager = FindObjectOfType<NeedsManager>();
        display_text = GetComponent<Text>();
    }

    void Update() {
        int time = needs_manager.TimeRemaining;
        display_text.text = "Time left: " + time;
    }
}
