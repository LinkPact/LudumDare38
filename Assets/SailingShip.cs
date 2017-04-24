using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailingShip : MonoBehaviour {

    private TextDisplay story_controller;
    public bool has_sailed;

    // Use this for initialization
    void Start () {
        story_controller = GameObject.FindObjectOfType<TextDisplay>();
        has_sailed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (has_sailed) {
            Sail();
        }
	}

    public void Sail() {
        FindObjectOfType<Camera>().center_trans = transform;
        story_controller.ShowText("You survived the island!\n\nMade for LudumDare 38 by Linkpact Games", this.gameObject);
    }
}
