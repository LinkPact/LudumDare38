using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerBar : MonoBehaviour {

    public Sprite body_sprite;
    public Sprite frame_sprite;

    public float hunger_frac = 0.8f;

    private float x;
    private float y;

    private NeedsManager needs_manager;

    void Start () {
        x = 10;
        y = 10;

        needs_manager = FindObjectOfType<NeedsManager>();
	}
	
	void Update () {
        hunger_frac = needs_manager.GetHungerFraction();
	}


    void OnGUI() {

        Texture body_text = body_sprite.texture;
        Texture frame_text = frame_sprite.texture;

        Rect body_text_rect = body_sprite.textureRect;
        Rect sub_rect = new Rect(body_text_rect.x / body_text.width, body_text_rect.y / body_text.height, body_text_rect.width / body_text.width * hunger_frac, body_text_rect.height / body_text.height);
        GUI.DrawTextureWithTexCoords(new Rect(x, y, body_text_rect.width * hunger_frac, body_text_rect.height), body_text, sub_rect);

        Rect frame_text_rect = frame_sprite.textureRect;
        Rect full_rect = new Rect(frame_text_rect.x / frame_text.width, frame_text_rect.y / frame_text.height, frame_text_rect.width / frame_text.width, frame_text_rect.height / frame_text.height);
        GUI.DrawTextureWithTexCoords(new Rect(x, y, frame_text_rect.width, frame_text_rect.height), frame_text, full_rect);
    }
}
