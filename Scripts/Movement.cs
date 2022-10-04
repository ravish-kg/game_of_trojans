using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float playerSpeed, dirX, dirY;

    private void Start() {
        playerSpeed = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        dirX = Input.GetAxis("Horizontal") * playerSpeed;
        dirY = Input.GetAxis("Vertical") * playerSpeed;
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dirX, dirY);
    }
}
