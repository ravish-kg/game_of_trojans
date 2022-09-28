using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 direction;
    
    public GameObject gameOverPanel;
    private GameObject player;
    public HealthBar healthBar;
    public int currHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.SetMaxHealth(100);
        currHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        float y_direction = Input.GetAxisRaw("Vertical");
        direction = new Vector2(0, y_direction).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, direction.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            currHealth -=  10;
            healthBar.SetHealth(currHealth);
        }

        if(currHealth <= 0) {
            Destroy(player.gameObject);
        }
    }
}
