using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Transform player_trans;

    private Vector3 orig_pos;

	void Start () {
        player_trans = GameObject.FindObjectOfType<Player>().gameObject.transform;
        orig_pos = transform.position;
	}
	
	void Update () {

        

        transform.position = new Vector3(player_trans.position.x, player_trans.position.y, orig_pos.z);
	}
}
