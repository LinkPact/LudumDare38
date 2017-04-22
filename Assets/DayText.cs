using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayText : MonoBehaviour {

    private NeedsManager needs_manager;
    private Text display_text;

	void Start () {
        needs_manager = FindObjectOfType<NeedsManager>();
        display_text = GetComponent<Text>();
	}
	
	void Update () {
        int day = needs_manager.Day;
        display_text.text = "Day: " + day;
	}
}
