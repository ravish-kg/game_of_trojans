using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player5 : MonoBehaviour
{
    public bool onGround;
    float speed = 5.0f;
    private Rigidbody2D player;
    private float direction = 0f;
    public float jumpSpeed = 8.0f;
    public bool gravityDown = true;

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

            if (onGround) {
                if (Input.GetButtonDown("Jump")) {
                    if (player.gravityScale == 1) {
                        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
                    }
                    else {
                        player.velocity = new Vector2(player.velocity.x, -1 * jumpSpeed);
                    }
                }
            }

            if (direction >= 0f) {
                transform.localScale = new Vector2(0.05833428f, 0.06382877f);
            }
            else {
                transform.localScale = new Vector2(-0.05833428f, 0.06382877f);
            }
        }
    }

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.CompareTag("hwalls")) {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.CompareTag("hwalls")) {
            onGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Darkboxes") {
            player.gravityScale = -1;
            if (gravityDown == true) {
                gravityDown = false;
                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + 180, gameObject.transform.eulerAngles.z + 180);
            }
        }
        else if (col.tag == "LightBoxes") {
            player.gravityScale = 1;
            if (gravityDown == false) {
                gravityDown = true;
                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + 180, gameObject.transform.eulerAngles.z + 180);
            }
        }
    }
}