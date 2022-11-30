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

    // Start is called before the first frame update
    void Start() {
        onGround = true;
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (NewTimer.exit_condition == 1) {
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
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.CompareTag("hwalls")) {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.CompareTag("hwalls")) {
            onGround = false;
        }
    }
}