using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float moveSpeed;
    [SerializeField] float bulletSpeed;

    [SerializeField] GameObject bullet;
    
    [SerializeField] Animator anim;

    [SerializeField] CameraMovement camMovement;

    void Update()
    {
        MovePlayer();
        if (Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    void MovePlayer() {
        if (Input.GetKey(KeyCode.W)) {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
        } else {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        } else if (Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }

    void Shoot() {
        StartCoroutine(camMovement.Shake(0.15f, 0.5f));
        Vector2 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
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
