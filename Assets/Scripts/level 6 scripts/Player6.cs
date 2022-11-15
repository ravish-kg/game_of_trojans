using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player6 : MonoBehaviour
{
    public bool onGround;
    float speed = 5.0f;
    private Rigidbody2D player;
    private float direction = 0f;
    public float jumpSpeed = 8.0f;
    public int gravityState = 1;
    public Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start() {
        onGround = true;
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (NewTimer.exit_condition == 1)
        {
            if(gravityState != 2) {
                direction = Input.GetAxisRaw("Horizontal");
            
                if (direction != 0f) {
                    player.velocity = new Vector2(direction * speed, player.velocity.y);
                }
                else {
                    player.velocity = new Vector2(0, player.velocity.y);
                }
                
                if(onGround) {
                    if(Input.GetButtonDown("Jump")) {
                        if(player.gravityScale==1) {
                            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
                        }
                        else {
                            player.velocity = new Vector2(player.velocity.x, -1 * jumpSpeed);
                        }
                        onGround = false;
                    }
                }
            }
            else {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)) {
                    movement.y = 0;
                }
                else {
                    movement.x = 0;
                }

                movement.Normalize();
                player.velocity = movement * speed;
            }

            if (direction >= 0f) {
                transform.localScale = new Vector2(0.05833428f, 0.06382877f);
            }
            else {
                transform.localScale = new Vector2(-0.05833428f, 0.06382877f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("hwalls")) {
            onGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Darkboxes") {
            player.gravityScale = 1;
            if (gravityState != 1) {
                gravityState = 1;
            }
        }
        else if (col.tag == "LightBoxes") {
            player.gravityScale = -1;
            if (gravityState != 3) {
                if(gravityState == 2) {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y+180, gameObject.transform.eulerAngles.z+180);
                }
                gravityState = 3;
            }
        }
        else if (col.tag == "RedBoxes") {
            player.gravityScale = 0;
            if (gravityState != 2) {
                if(gravityState == 3) {
                    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y+180, gameObject.transform.eulerAngles.z+180);
                }
                gravityState = 2;
            }
        }
    }
}