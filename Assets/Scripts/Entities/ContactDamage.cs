using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField] string[] tags = new string[3];
    [SerializeField] int damage = 1;


    void OnCollisionEnter2D(Collision2D col) {
        foreach (string tag in tags)
        {
            if (col.gameObject.CompareTag(tag)) {
                Damageable otherDamageable = col.gameObject.GetComponent<Damageable>();
                if (otherDamageable != null) {
                    otherDamageable.TakeDamage(damage);
                }
            }
        }
    }
}
