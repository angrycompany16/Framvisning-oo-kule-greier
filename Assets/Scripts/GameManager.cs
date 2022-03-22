using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    [SerializeField] Damageable playerDamageable;
    [SerializeField] CameraMovement camMovement;

    public void Reset() {
        StartCoroutine(camMovement.Shake(1f, 3f));
        fadeAnim.SetBool("Failed", true);
    }

    public void ReloadScene() {
        SceneManager.LoadScene(0);
    }

    public void DamageFlash() {
        fadeAnim.Play("Black-fade-out-fast");
    }

}