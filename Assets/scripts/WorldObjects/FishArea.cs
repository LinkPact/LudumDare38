using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishArea : MonoBehaviour {

    public GameObject fish_prefab;

    private float current_spawn_time;
    public float fish_spawn_time = 60;

    public float max_spawn_offset = 1;

	void Start () {
        current_spawn_time = 0;
        SpawnFish();
    }
	
	void Update () {
        UpdateSpawn();        
	}

    private void UpdateSpawn() {
        current_spawn_time += Time.deltaTime;
        if (current_spawn_time > fish_spawn_time) {
            SpawnFish();
            current_spawn_time = 0;
        }
    }

    private void SpawnFish() {
        GameObject new_fish = Instantiate(fish_prefab);
        new_fish.transform.position = RandomizePosition(transform.position, max_spawn_offset);
    }

    private Vector3 RandomizePosition(Vector3 orig_pos, float rand_dist) {
        float new_x = orig_pos.x + Random.Range(-rand_dist / 2, rand_dist / 2);
        float new_y = orig_pos.y + Random.Range(-rand_dist / 3, 0);
        return new Vector3(new_x, new_y, orig_pos.z);
    }
}
