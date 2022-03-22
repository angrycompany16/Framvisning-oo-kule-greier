using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] GameObject bullet;

    [SerializeField] float range;
    [SerializeField] float shotsPerSec;
    [SerializeField] float bulletSpeed;
    float time = 0;

    void Start() {
        GameObject playerObj = GameObject.FindWithTag("Player");
        target = playerObj.transform;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > 1 / shotsPerSec) {
            time = 0;
            Shoot();
        }        
    }

    void Shoot() {
        Vector2 lookDir = target.position - transform.position;
        lookDir.Normalize();

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector2.Dot(lookDir, Vector2.right));
        
        if (lookDir.y < 0) {
            bulletRb.transform.rotation = Quaternion.Euler(0f, 0f, 360 - angle);
        } else {
            bulletRb.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        bulletRb.velocity = lookDir * bulletSpeed;
    }
}
