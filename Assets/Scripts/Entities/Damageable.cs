using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THis is kinda garbage. I shouldn't have made this much custom behaviour in a base class, but ohh wellll

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    [SerializeField] HPbar hpBar;
    [SerializeField] PlayerHPbar playerHpBar;
    [SerializeField] GameManager gameManager;

    public SpawnObjects spawner;

    bool isPlayer;

    CameraMovement camMovement;

    [SerializeField] float iFrames;

    void Start() {
        currentHealth = maxHealth;
        camMovement = Camera.main.GetComponent<CameraMovement>();
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth < 0) {
            currentHealth = 0;
        }

        if (hpBar != null) {
            hpBar.UpdateHPBar(damage, currentHealth);
            StartCoroutine(camMovement.Shake(0.2f, 0.5f));
        } else if (playerHpBar != null) {
            playerHpBar.UpdateHPBar(damage, currentHealth);
            isPlayer = true;
        }

        if (isPlayer && currentHealth > 0) {
            gameManager.DamageFlash();
            StartCoroutine(camMovement.Shake(0.2f * damage, 0.75f * damage));
        } 
        
        if (iFrames > 0) {

        }

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        if (isPlayer) {
            spawner.enabled = false;
            gameManager.Reset();
        } else {
            spawner.timeSinceLastKill = 0;
        }
        gameObject.SetActive(false);
    }

    IEnumerator InvincibilityFrames (float duration) {
        float t = 0;
        while (t < duration) {
            t += Time.deltaTime;
            
            Physics.IgnoreLayerCollision(6, 9);

            yield return null;
        }

        Physics.IgnoreLayerCollision(6, 9, false);
    }
}
