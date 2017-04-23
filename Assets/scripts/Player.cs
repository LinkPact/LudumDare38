using UnityEngine;

public class Player : MonoBehaviour {

    public float move_speed = 0.01f;
    public Sprite grave_sprite;
    private bool alive = true;

    private SpriteRenderer sprite_renderer;
    private Rigidbody2D rigi;

	void Start () {
        sprite_renderer = GetComponent<SpriteRenderer>();
        rigi = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (alive) {
            UpdateMovement();
        }
	}

    private void UpdateMovement() {

        float horiz_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");

        if (horiz_input != 0) {
            transform.position = new Vector2(transform.position.x + move_speed * horiz_input, transform.position.y);
        }

        if (vertical_input != 0) {
            transform.position = new Vector2(transform.position.x, transform.position.y + move_speed * vertical_input);
        }
    }

    public void Died() {
        sprite_renderer.sprite = grave_sprite;
        alive = false;
    }
}
