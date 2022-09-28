using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate() {
        rb.velocity = transform.right * bulletSpeed;
    }
}
