using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform center_trans;

    private Vector3 orig_pos;

	void Start () {
        center_trans = GameObject.FindObjectOfType<Player>().gameObject.transform;
        orig_pos = transform.position;
	}
	
	void Update () {

        transform.position = new Vector3(center_trans.position.x, center_trans.position.y, orig_pos.z);
	}
}
