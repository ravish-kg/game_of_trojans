using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;

    private void Update() {
        if (Input.GetKeyDown("space") && timeUntilFire < Time.time) {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
    }
}
