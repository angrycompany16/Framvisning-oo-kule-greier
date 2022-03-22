using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletBehaviour : MonoBehaviour
{
    float time = 0;
    float maxTime = 4;

    [SerializeField] string[] tags = new string[3];
    [SerializeField] GameObject collisionParticles;
    [SerializeField] int damage = 1;


    void Update()
    {
        time += Time.deltaTime;
        if (time > maxTime) {
            Destroy(gameObject);
        }      
    }

    void OnCollisionEnter2D(Collision2D col) {
        foreach (string tag in tags)
        {
            if (col.gameObject.CompareTag(tag)) {
                Damageable otherDamageable = col.gameObject.GetComponent<Damageable>();
                if (otherDamageable != null) {
                    otherDamageable.TakeDamage(damage);
                }

                Instantiate(collisionParticles, transform.position, Quaternion.identity);

                Destroy(gameObject);

            }
        }
    }
}
