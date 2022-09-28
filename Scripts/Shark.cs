using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border") {
            Destroy(gameObject);
        }
        else if (collision.tag == "Bullet") {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Player") {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
