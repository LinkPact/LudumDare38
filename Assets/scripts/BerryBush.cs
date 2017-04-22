using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : MonoBehaviour {

    public Sprite[] sprites;

    public bool has_berries = true;

    private SpriteRenderer sprite_renderer;
    //private NeedsManager needs;

	void Start () {
        sprite_renderer = GetComponent<SpriteRenderer>();
        //needs = GameObject.FindObjectOfType<NeedsManager>();
	}
	
	void Update () {
		
        if (has_berries) {
            sprite_renderer.sprite = sprites[0];
        }
        else {
            sprite_renderer.sprite = sprites[1];
        }
	}

    void OnMouseDown() {
        has_berries = !has_berries;
        //needs.
    }
}
