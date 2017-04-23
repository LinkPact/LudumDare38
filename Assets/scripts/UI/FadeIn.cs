using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fade_in_time;
    private float time_pased;

    private Image fadePanel;
    private Color currentColor = Color.black;

	void Start () {
		fadePanel = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
	}
	
    public void StartFade() {
        time_pased = 0;
        currentColor = Color.black;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

	void Update () {
        time_pased += Time.deltaTime;
		if (Time.timeSinceLevelLoad < fade_in_time) {
            float alphaChange = Time.deltaTime / fade_in_time;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
	}

}
