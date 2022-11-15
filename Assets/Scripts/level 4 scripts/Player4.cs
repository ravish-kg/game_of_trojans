using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4 : MonoBehaviour
{
    public bool onGround;
    float speed = 5.0f;
    private Rigidbody2D player;
    private float direction = 0f;
    public float jumpSpeed = 8.0f;
    // public Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start() {
        onGround = true;
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (NewTimer.exit_condition == 1)
        {
            direction = Input.GetAxisRaw("Horizontal");
            
            if (direction != 0f) {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
            }
            else {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if(onGround) {
                if(Input.GetButtonDown("Jump")) {
                    player.velocity = new Vector2(player.velocity.x, jumpSpeed);
                    onGround = false;
                }
            }

            // direction = Input.GetAxis("Horizontal");
            // if (direction >= 0f) {
            //     transform.localScale = new Vector2(0.05833428f, 0.06382877f);
            // }
            // else {
            //     transform.localScale = new Vector2(-0.05833428f, 0.06382877f);
            // }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        col.gameObject.CompareTag("Walls");
        onGround = true;
    }
}