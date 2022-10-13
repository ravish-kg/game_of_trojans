using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 5.0f;
    private Rigidbody2D _rigidbody;
    float direction;
    public Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.Translate(-speed*Time.deltaTime,0,0);
        // }
        // else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.Translate(speed*Time.deltaTime,0,0);
        // }
        // else if(Input.GetKey(KeyCode.UpArrow)){
        //     transform.Translate(0,speed*Time.deltaTime,0);
        // }
        // else if(Input.GetKey(KeyCode.DownArrow)){
        //     transform.Translate(0,-speed*Time.deltaTime,0);
        // }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(movement.x) > Mathf.Abs(movement.y)) {
            movement.y = 0;
        }
        else {
            movement.x = 0;
        }

        movement.Normalize();

        _rigidbody.velocity = movement * speed;
        direction = Input.GetAxis("Horizontal");
        if(direction >= 0f)
        {
            transform.localScale = new Vector2(0.05833428f, 0.06382877f);

        } else
        {
            transform.localScale = new Vector2(-0.05833428f, 0.06382877f);
        }


    }

    // private void OnCollisionEnter2D(Collision2D collision){
    //     if(collision.gameObject.tag == "Darkboxes"){
    //         Destroy(collision.gameObject);
    //         //logic for darkboxes
    //     }

    //     if(collision.gameObject.tag == "LightBoxes"){
    //         Destroy(collision.gameObject);
    //     }


    //     if(collision.gameObject.tag == "Walls"){
    //            if(Input.GetKey(KeyCode.LeftArrow)){
    //         transform.Translate(speed*Time.deltaTime,0,0);
    //     }
    //      if(Input.GetKey(KeyCode.RightArrow)){
    //         transform.Translate(-speed*Time.deltaTime,0,0);
    //     }
    //      if(Input.GetKey(KeyCode.UpArrow)){
    //         transform.Translate(0,-speed*Time.deltaTime,0);
    //     }
    //      if(Input.GetKey(KeyCode.DownArrow)){
    //         transform.Translate(0,speed*Time.deltaTime,0);
    //     }
    //     }
    // }
}
