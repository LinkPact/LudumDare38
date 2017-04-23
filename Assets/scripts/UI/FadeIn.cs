using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fade_in_time;
    private float time_passed;

    private Color start_color = Color.black;
    private Color currentColor;
    private FadePanel fade_panel_script;
    private Image panel_image;

	void Start () {
        fade_panel_script = GetComponentInChildren<FadePanel>();
        panel_image = fade_panel_script.gameObject.GetComponent<Image>();
        currentColor = start_color;
	}
	
    public void StartFade() {
        time_passed = 0;
        currentColor = Color.black;
        fade_panel_script.gameObject.SetActive(true);
    }

	void Update () {
        time_passed += Time.deltaTime;
		if (time_passed < fade_in_time) {
            float alphaChange = Time.deltaTime / fade_in_time;
            currentColor.a -= alphaChange;
            panel_image.color = currentColor;
        }
        else {
            fade_panel_script.gameObject.SetActive(false);
        }
	}

}
